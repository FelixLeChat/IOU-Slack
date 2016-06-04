using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands
{
    public enum CommandType
    {
        [Description("create event")]
        CreateEvent,
        [Description("register to")]
        RegisterToEvent,
        Null
    }
}