namespace IOU_Slack_Backend
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }

        public string CreatorUserId { get; set; }
        public string CreatorUsername { get; set; }

        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
    }
}