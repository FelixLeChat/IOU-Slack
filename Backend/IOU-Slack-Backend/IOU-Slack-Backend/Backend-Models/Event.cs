﻿namespace IOU_Slack_Backend
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }

        public string CreatorUserId { get; set; }
        public string CreatoruserName { get; set; }

        public string ChannelId { get; set; }
        public string ChannelName { get; set; }

        // Slack Bot will setup the rest
        public string Description { get; set; }
    }
}