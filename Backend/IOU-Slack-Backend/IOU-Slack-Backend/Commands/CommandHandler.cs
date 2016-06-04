using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend
{
    public class CommandHandler
    {
        public Command Command { get; set; }

        public CommandHandler(CommandRequest commandRequest, CommandType commandType)
        {
            this.Command = CommandFactory.Create(commandType, commandRequest);
        }

        public bool ValidateCommand()
        {
            return this.Command.ValidateToken();
        }

        public CommandResponse Execute()
        {
            this.Command.Execute();

            return this.Command.CommandResponse;
        }
    }
}