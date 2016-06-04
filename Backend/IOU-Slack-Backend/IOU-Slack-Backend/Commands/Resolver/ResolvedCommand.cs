using IOU_Slack_Backend.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands.Resolver
{
    public class ResolvedCommand
    {
        public CommandType Type { get; set; }
        public string Parameters { get; set; }
    }
}