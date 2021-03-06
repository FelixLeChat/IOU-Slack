﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IOU_Slack_Backend.Commands.Models
{
    public enum CommandType
    {
        [Description(@"new event ([^\s]*)")]
        CreateEvent,
        [Description(@"join ([^\s]*)")]
        SubscribeToEvent,
        [Description(@"pay ([^\$]*)\$ for ([^\s]*) using ([^\s]*)")]
        PayFor,
        [Description(@"split ([^\s]*) ([^\$]*)\$ ([^\s]*)")]
        Split,
        [Description(@"fix ([^\s]*) ([^\$]*)\$ ([^\s]*)")]
        Fix,
        [Description(@"add reminder to ([^\s]*) ([^\s]*)")]
        AddReminder
    }
}