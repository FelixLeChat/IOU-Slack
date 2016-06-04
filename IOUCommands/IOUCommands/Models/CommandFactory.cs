using IOUCommands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOUCommands.Models
{
    public static class CommandFactory
    {
        public static Command Create(CommandType type, CommandRequest commandRequest)
        {
            Command command = null;

            switch(type)
            {
                case CommandType.IOU:
                    command = new IOUCommand(commandRequest);
                        break;
                case CommandType.UOI:
                    command = new UOICommand(commandRequest);
                    break;
            }

            return command;
        }
    }
}