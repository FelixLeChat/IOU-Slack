using IOU_Slack_Backend.Backend_Models;
using IOU_Slack_Backend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Models;

namespace IOU_Slack_Backend.Services
{
    public class EventSubscriptionService : AbstractService<EventSubscription>
    {
        public int GetParticipantCount(string eventID)
        {
             return GetAll(eventID).Count; 
        }

        public void Subscribe(SubscribeModel subscribeModel)
        {
            // Check if there is a subscription with the same parameter
            var subscription = Get(EventSubscriptionHelper.GetEventSubscriptionId(subscribeModel));

            if (subscription != null)
                throw HttpResponseExceptionHelper.Create(
                    "There is already a subscription that exist between the user : " + subscribeModel.UserID +
                    " And the event " + subscribeModel.EventID, HttpStatusCode.BadRequest);

            // create subscription
            Create(new EventSubscription()
            {
                EventID = subscribeModel.EventID,
                UserID = subscribeModel.UserID
            });
        }

        public void Unsubscribe(SubscribeModel unsubscribModel)
        {
            var subscription = Get(EventSubscriptionHelper.GetEventSubscriptionId(unsubscribModel));

            if (subscription == null)
                throw HttpResponseExceptionHelper.Create("No subscription to unsubcribe from", HttpStatusCode.BadRequest);

            // Delete Subscription
            Delete(new EventSubscription()
            {
                EventSubscriptionID = EventSubscriptionHelper.GetEventSubscriptionId(unsubscribModel)
            });
        }

        public override void Create(EventSubscription element)
        {
            if (element == null)
                throw HttpResponseExceptionHelper.Create("Element you want to create is null (Event Subscription)",
                    HttpStatusCode.BadRequest);

            using (var db = new SystemDbContext())
            {
                element.EventSubscriptionID = EventSubscriptionHelper.GetEventSubscriptionId(element);
                db.EventSubscriptions.Add(element);
                db.SaveChanges();
            }
        }

        public override void Delete(EventSubscription element)
        {
            if (element == null)
                throw HttpResponseExceptionHelper.Create("The element you want to create is null (EventSubscription)",
                    HttpStatusCode.BadRequest);

            using (var db = new SystemDbContext())
            {
                var eventSubscription =
                    db.EventSubscriptions.FirstOrDefault(x => x.EventSubscriptionID == element.EventSubscriptionID);

                if (eventSubscription == null)
                    throw HttpResponseExceptionHelper.Create(
                        "The subscription you want to delete is not in the database", HttpStatusCode.BadRequest);

                db.EventSubscriptions.Remove(eventSubscription);
            }
        }

        public override EventSubscription Get(string id)
        {
            using (var db = new SystemDbContext())
            {
                return db.EventSubscriptions.FirstOrDefault(x => x.EventSubscriptionID == id);
            }
        }

        public override List<EventSubscription> GetAll()
        {
            using (var db = new SystemDbContext())
            {
                return db.EventSubscriptions.ToList();
            }
        }

        public List<EventSubscription> GetAll(string eventID)
        {
            using (var db = new SystemDbContext())
            {
                return db.EventSubscriptions.Where(x => x.EventID == eventID).ToList();
            }
        }

        public override void Update(EventSubscription element)
        {
            throw new NotImplementedException();
        }
        public string GetUserNameById(string id, string eventId)
        {
            using (var db = new SystemDbContext())
            {
                return db.EventSubscriptions.FirstOrDefault(e => e.EventID == eventId && e.UserID == id ).UserName;
            }
        }
       
    }
}