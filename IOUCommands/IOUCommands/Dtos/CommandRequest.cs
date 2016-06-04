using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOUCommands.Dtos
{
    public class CommandRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("team_id")]
        public string TeamID { get; set; }
        [JsonProperty("team_domain")]
        public string TeamDomain { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelID { get; set; }
        [JsonProperty("channel_name")]
        public string ChannelName { get; set; }
        [JsonProperty("user_id")]
        public string UserID { get; set; }
        [JsonProperty("user_name")]
        public string Username { get; set; }
        [JsonProperty("command")]
        public string CommandName { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("response_url")]
        public string ResponseURL { get; set; }
    }
}