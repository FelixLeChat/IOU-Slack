using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands.Models
{
    public class PayForCommand : Command
    {
        public PayForCommand(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.PayFor;
        }

        public override void Execute()
        {
            var userId = this.CommandRequest.User_ID;
            var eventName = this.Parameters[0];
            var channelId = this.CommandRequest.Channel_ID;

            var e = new EventService()
                .GetByName(eventName, channelId);

            
        }
    }
}