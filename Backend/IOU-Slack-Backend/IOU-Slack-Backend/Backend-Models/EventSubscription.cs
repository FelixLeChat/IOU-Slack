using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Backend_Models
{
    public class EventSubscription
    {
        public int ID { get; set; }
        public string EventID { get; set; }
        public string UserId { get; set; }
    }
}