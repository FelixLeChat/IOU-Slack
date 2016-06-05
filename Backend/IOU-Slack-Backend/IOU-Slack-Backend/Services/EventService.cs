using System.Collections.Generic;
using System.Linq;
using System.Net;
using IOU_Slack_Backend.Context;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Backend_Models;
using IOU_Slack_Backend.Models;

namespace IOU_Slack_Backend.Services
{
    public class EventService : AbstractService<Event>
    {
        public List<string> Split(SplitFixModel splitFixModel)
        {
            var eventSubeventSubscriptionService = new EventSubscriptionService();

            // Get User List
            var users = eventSubeventSubscriptionService.GetAll(splitFixModel.EventID);
            var participantCount = users.Count;
            if (participantCount == 0)
                throw HttpResponseExceptionHelper.Create("No one has subscribed to the event", HttpStatusCode.BadRequest);

            splitFixModel.Amount = splitFixModel.Amount/participantCount;

            return Fix(splitFixModel);
        }

        public List<string> Fix(SplitFixModel splitFixModel)
        {
            var eventSubeventSubscriptionService = new EventSubscriptionService();

            var eventSubscriptions = eventSubeventSubscriptionService.GetAll(splitFixModel.EventID);

            // Get Current Event
            var ev = Get(splitFixModel.EventID);

            // update Event
            Update(ev);

            // Generate Debts
            var userList = new List<string>();
            var debtService = new DebtService();

            foreach (var eventSubscription in eventSubscriptions)
            {
                userList.Add(eventSubscription.UserName);
                // Debt Creation
                debtService.Create(new Debt()
                {
                    AmountDue = ev.Price,
                    EventID = splitFixModel.EventID,
                    UserID = eventSubscription.UserID
                });
            }

            return userList;
        }

        public void CloseEvent(string eventID)
        {
            var ev = Get(eventID);

            if (ev == null)
                throw HttpResponseExceptionHelper.Create("No event linked to ID when closing : " + eventID,
                    HttpStatusCode.BadRequest);

            Update(ev);
        }

        public override List<Event> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override Event Get(string id)
        {
            using (var db = new SystemDbContext())
            {
                return db.Events.FirstOrDefault(x => x.EventID == id);
            }
        }

        public override void Delete(Event element)
        {
            throw new System.NotImplementedException();
        }

        public override void Create(Event element)
        {
            using (var db = new SystemDbContext())
            {
                // set event ID
                element.EventID = Sha1Hash.GetSha1HashData(element.ChannelID + ":" + element.CreatorID);

                db.Events.Add(element);
                db.SaveChanges();
            }
        }

        public override void Update(Event element)
        {
            if (element == null)
                throw HttpResponseExceptionHelper.Create("Update element in null", HttpStatusCode.BadRequest);

            var ev = Get(element.EventID);

            if (ev == null)
                throw HttpResponseExceptionHelper.Create("No event linked to ID when Updating : " + element.EventID,
                    HttpStatusCode.BadRequest);

            using (var db = new SystemDbContext())
            {
                // Refind element to delete in list
                var dbEvent = db.Events.FirstOrDefault(x => x.EventID == element.EventID);
                db.Events.Remove(dbEvent);
                db.SaveChanges();
            }
        }

        public Event GetByName(string eventName, string channelId)
        {
            using (var db = new SystemDbContext())
            {
                return db.Events.Single(e => e.Name == eventName && e.ChannelID == channelId);
            }
        }
        public Event GetEventByCreatorId(string eventName, string creatorUserId)
        {
            using (var db = new SystemDbContext())
            {
                return db.Events.Single(e => e.Name == eventName && e.CreatorID == creatorUserId);
            }
        }
    }
}