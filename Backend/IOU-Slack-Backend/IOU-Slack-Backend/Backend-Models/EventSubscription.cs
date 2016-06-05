using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Backend_Models
{
    public class EventSubscription
    {
        public int EventID { get; set; }
        public string UserID { get; set; }
    }
}