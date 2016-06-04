using IOU_Slack_Backend.Commands.Models;
using IOU_Slack_Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands
{
    public static class CommandFactory
    {
        public static Command Create(CommandType type, string parameters, CommandRequest commandRequest)
        {
            Command command = null;

            switch (type)
            {
                case CommandType.CreateEvent:
                    command = new CreateEventCommand(parameters, commandRequest);
                    break;
                case CommandType.SubscribeToEvent:
                    //command = new UOICommand(commandRequest);
                    break;
            }

            return command;
        }
    }
}