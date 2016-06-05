using System;
using IOU_Slack_Backend.Helper;

namespace IOU_Slack_Backend
{
    public class Event
    {
        public int ID { get; set; }
        public string EventID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }

        public string CreatorID { get; set; }
        public string CreatorUsername { get; set; }

        public string ChannelID { get; set; }
        public string ChannelName { get; set; }

        public double Price { get; set; }

        public DateTime RegistrationDeadline { get; set; }
        public DateTime PaymentDeadline { get; set; }
    }

    public class EventHelper
    {
        public static string GetID(Event ev)
        {
            return Sha1Hash.GetSha1HashData(ev.Name + ev.ChannelID + ev.CreatorID);
        }
    }
}