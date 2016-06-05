using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Backend_Models
{
    public class Reminder
    {
        public int ID { get; set; }

        public int EventID { get; set; }

        public DateTime DateTime { get; set; }
        public bool isTriggered { get; set; }
        public int Type { get; set; }
    }
}