using System.Collections.Generic;
using IOU_Slack_Backend.Context;

namespace IOU_Slack_Backend.Services
{
    public class EventService : AbstractService<Event>
    {
        public override List<Event> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public override Event Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Event element)
        {
            throw new System.NotImplementedException();
        }

        public override void Create(Event element)
        {
            using (var db = new SystemDbContext())
            {
                db.Events.Add(element);
                db.SaveChanges();
            }
        }

        public override void Update(Event element)
        {
            throw new System.NotImplementedException();
        }
    }
}