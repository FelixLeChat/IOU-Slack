using IOUCommands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOUCommands.Models
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