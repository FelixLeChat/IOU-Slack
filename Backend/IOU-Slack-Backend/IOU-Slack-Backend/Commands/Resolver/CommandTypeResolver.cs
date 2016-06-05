using IOU_Slack_Backend.Commands.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace IOU_Slack_Backend.Commands.Resolver
{
    public static class CommandTypeResolver
    {
        public static ResolvedCommand Resolve(string text)
        {
            foreach (CommandType type in Enum.GetValues(typeof(CommandType)))
            {
                var pattern = type.GetDescription();

                var match = Regex.Match(text, pattern);

                if (match.Success)
                {
                    var resolvedCommand = new ResolvedCommand
                    {
                        Parameters = match.Groups.Cast<Group>().Skip(1).Select(g => g.Value).ToArray(),
                        Type = type
                    };

                    return resolvedCommand;
                }
            }

            return null;
        }
    }
}