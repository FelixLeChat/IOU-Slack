namespace IOU_Slack_Backend.Backend_Models
{
    public class EventSubscription
    {
        public int id { get; set; }
        public string EventID { get; set; }
        public string UserID { get; set; }
    }
}