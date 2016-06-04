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

        public CommandHandler(CommandRequest commandRequest)
        {
            ResolvedCommand resolvedCommand = this.ResolveCommandType(commandRequest.Text);

            this.Command = CommandFactory.Create(resolvedCommand.Type, resolvedCommand.Parameters, commandRequest);
        }

        private ResolvedCommand ResolveCommandType(string text)
        {
            return CommandTypeResolver.Resolve(text);
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