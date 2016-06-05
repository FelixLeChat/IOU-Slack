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
        public static Command Create(CommandType type, string[] parameters, CommandRequest commandRequest)
        {
            Command command = null;

            switch (type)
            {
                case CommandType.CreateEvent:
                    command = new CreateEventCommand(parameters, commandRequest);
                    break;
                case CommandType.SubscribeToEvent:
                    command = new SubscribeToEventCommand(parameters, commandRequest);
                    break;
                case CommandType.Split:
                    command = new SplitFixCommand(parameters, commandRequest, CommandType.Split);
                    break;
                case CommandType.Fix:
                    command = new SplitFixCommand(parameters, commandRequest, CommandType.Fix);
                    break;
                case CommandType.PayFor:
                    command = new PayForCommand(parameters, commandRequest);
                    break;
                case CommandType.AddReminder:
                    command = new AddReminderCommand(parameters, commandRequest);
                    break;
            }

            return command;
        }
    }
}