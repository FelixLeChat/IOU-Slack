﻿using IOU_Slack_Backend.Dtos;
using System.Collections.Specialized;
using System.Net;
using SlackAPI;
using Newtonsoft.Json;

namespace IOU_Slack_Backend.Commands
{
    public class UOICommand : Command
    {
        public UOICommand(CommandRequest commandRequest) : base(commandRequest)
        {
            this.Type = CommandType.UOI;
            this.ValidationToken = "O1oPnnCbPWf89Cgevwzc1Ztn";
        }

        public override void Execute()
        {
            
        }
        public string createUser()
        {
            WebClient client = new WebClient();
            var response = client.UploadValues("https://slack.com/api/channels.info", "POST", new NameValueCollection() {
            {"token",this.ValidationToken},
            {"channel",CommandRequest.ChannelID}});
            Channel channel = JsonConvert.DeserializeObject<Channel>(System.Text.Encoding.UTF8.GetString(response));
            return channel.name;
        } 
           
    } 
}