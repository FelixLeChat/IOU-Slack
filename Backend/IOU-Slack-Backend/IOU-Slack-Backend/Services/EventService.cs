using System.Collections.Generic;
using System.Linq;
using System.Net;
using IOU_Slack_Backend.Context;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Models;

namespace IOU_Slack_Backend.Services
{
    public class EventService : AbstractService<Event>
    {
        public List<string> Split(SplitModel splitModel)
        {
            // Setup Event Cost
            var ev = Get(splitModel.EventID);

            var eventSubeventSubscriptionService = new EventSubscriptionService();
            var participantCount = eventSubeventSubscriptionService.GetParticipantCount(splitModel.EventID);
            if (participantCount == 0)
                throw HttpResponseExceptionHelper.Create("No one has subscribed to the event", HttpStatusCode.BadRequest);

            ev.Price = splitModel.Amount/participantCount;

            // update Event
            Update(ev);


            // Generate Debts
        }

        public void CloseEvent(string eventID)
        {
            var ev = Get(eventID);

            if (ev == null)
                throw HttpResponseExceptionHelper.Create("No event linked to ID when closing : " + eventID,
                    HttpStatusCode.BadRequest);

            ev.IsClosed = true;
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
                element.EventID = Sha1Hash.GetSha1HashData(element.ChannelId + ":" + element.CreatorUserId);

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
                return db.Events.Single(e => e.EventName == eventName && e.ChannelId == channelId);
            }
        }

        public Event GetEventByAdminId(string eventName, string creatorUserId)
        {
            using (var db = new SystemDbContext())
            {
                return db.Events.Single(e => e.EventName == eventName && e.CreatorUserId == creatorUserId);
            }
        }
    }
}