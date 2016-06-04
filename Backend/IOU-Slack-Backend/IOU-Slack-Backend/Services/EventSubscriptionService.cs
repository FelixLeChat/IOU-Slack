using IOU_Slack_Backend.Backend_Models;
using IOU_Slack_Backend.Context;
using System;
using System.Collections.Generic;

namespace IOU_Slack_Backend.Services
{
    public class EventSubscriptionService : AbstractService<EventSubscription>
    {
        public override void Create(EventSubscription element)
        {
            using (var db = new SystemDbContext())
            {
                db.EventSubscriptions.Add(element);
                db.SaveChanges();
            }
        }

        public override void Delete(EventSubscription element)
        {
            throw new NotImplementedException();
        }

        public override EventSubscription Get(string id)
        {
            throw new NotImplementedException();
        }

        public override List<EventSubscription> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(EventSubscription element)
        {
            throw new NotImplementedException();
        }
    }
}