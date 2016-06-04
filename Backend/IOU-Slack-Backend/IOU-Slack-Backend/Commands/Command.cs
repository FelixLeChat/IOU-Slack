using IOU_Slack_Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands
{
    public abstract class Command
    {
        public CommandType Type { get; set; }
        public string ValidationToken { get; set; }

        public CommandRequest CommandRequest { get; set; }
        public CommandResponse CommandResponse { get; set; }

        public Command(CommandRequest commandRequest)
        {
            this.CommandRequest = commandRequest;
        }

        public bool ValidateToken()
        {
            return this.CommandRequest.Token == this.ValidationToken;
        }

        public abstract void Execute();
    }
}