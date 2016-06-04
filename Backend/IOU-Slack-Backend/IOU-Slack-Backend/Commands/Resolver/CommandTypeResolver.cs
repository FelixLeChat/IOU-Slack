using IOU_Slack_Backend.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands.Resolver
{
    public static class CommandTypeResolver
    {
        public static ResolvedCommand Resolve(string text)
        {
            var resolvedCommand = new ResolvedCommand();

            foreach (CommandType type in Enum.GetValues(typeof(CommandType)))
            {
                var commandText = type.GetDescription();

                if (text.StartsWith(commandText))
                {
                    resolvedCommand.Parameters = text.Replace(commandText + " ", "");
                    resolvedCommand.Type = type;

                    return resolvedCommand;
                }
            }

            return null;
        }
    }
}