using IOU_Slack_Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands
{
    public class CreateEventCommand : Command
    {
        public CreateEventCommand(string parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.CreateEvent;
            this.ValidationToken = "QV9RtOG4wtlriresDpig08zx";
        }

        public override void Execute()
        {
            //channelId, userId, name of event, username, channelname
        }
    }
}