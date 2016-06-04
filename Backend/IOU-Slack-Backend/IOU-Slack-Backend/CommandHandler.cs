using IOUCommands.Dtos;
using IOUCommands.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOUCommands
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

        public string Execute()
        {
            this.Command.Execute();

            return JsonConvert.SerializeObject(this.Command.CommandResponse);
        }
    }
}