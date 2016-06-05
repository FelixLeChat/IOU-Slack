namespace IOU_Slack_Backend
{
    public class Event
    {
        public int Id { get; set; }
        public string EventID { get; set; }
        public string EventName { get; set; }

        public string CreatorUserId { get; set; }
        public string CreatorUsername { get; set; }

        public string ChannelId { get; set; }
        public string ChannelName { get; set; }

        // Slack Bot will setup the rest
        public string Description { get; set; }


        // Server setup the rest
        public bool IsClosed { get; set; }
        public float Price { get; set; }
    }
}