using IOU_Slack_Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands
{
    public class IOUCommand : Command
    {
        public IOUCommand(CommandRequest commandRequest) : base(commandRequest)
        {
            this.Type = CommandType.IOU;
            this.ValidationToken = "QV9RtOG4wtlriresDpig08zx";
        }

        public override void Execute()
        {

        }
    }
}