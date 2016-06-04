using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Dtos
{
    public class CommandRequest
    {
        public string Token { get; set; }
        public string Team_ID { get; set; }
        public string Team_Domain { get; set; }
        public string Channel_ID { get; set; }
        public string Channel_Name { get; set; }
        public string User_ID { get; set; }
        public string User_Name { get; set; }
        public string Command { get; set; }
        public string Text { get; set; }
        public string Response_Url { get; set; }
    }
}