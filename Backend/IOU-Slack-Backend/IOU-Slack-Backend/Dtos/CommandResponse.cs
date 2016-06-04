using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Dtos
{
    public class CommandResponse
    {
        [JsonProperty("response_type")]
        public string ResponseType { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("attachments")]
        public string[] Attachments { get; set; }

        public CommandResponse()
        {
            this.ResponseType = "in_channel";
            this.Text = "";
        }
    }
}