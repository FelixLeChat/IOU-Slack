﻿using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/command")]
    public class CommandController : ApiController
    {
        [HttpPost]
        [Route("uoi")]
        public CommandResponse UOI(CommandRequest commandRequest)
        {
            CommandHandler commandHandler = new CommandHandler(commandRequest, CommandType.UOI);

            if (!commandHandler.ValidateCommand())
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            var commandResponse = commandHandler.Execute();

            return commandResponse;
        }

        [HttpPost]
        [Route("iou")]
        public string IOU()
        {
            return "test";
        }

        [HttpPost]
        [Route("test")]
        public IHttpActionResult Get()
        {
            return this.Ok("Get!!");
        }
    }
}
