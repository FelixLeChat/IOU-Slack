using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Models;

namespace IOU_Slack_Backend
{
    public class EventSubscription
    {
        public int id { get; set; }

        public string EventSubscriptionID { get; set; }
        public string EventID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
    }

    public class EventSubscriptionHelper
    {
        public static string GetEventSubscriptionId(EventSubscription eventSubscription)
        {
            return Sha1Hash.GetSha1HashData(eventSubscription.EventID + eventSubscription.UserID);
        }

        public static string GetEventSubscriptionId(SubscribeModel model)
        {
            return Sha1Hash.GetSha1HashData(model.EventID + model.UserID);
        }
    }
}