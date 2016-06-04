using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands.Models
{
    public enum CommandType
    {
        [Description(@"create event ([^\s]*)")]
        CreateEvent,
        [Description(@"subscribe to ([^\s]*)")]
        SubscribeToEvent,
        [Description(@"pay for ([^\s]*) by ([^\s]*)")]
        PayFor,
        [Description(@"close registrations of ([^\s]*)")]
        CloseRegistration
    }
}