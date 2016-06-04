using IOU_Slack_Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            ///
        }
    }
}