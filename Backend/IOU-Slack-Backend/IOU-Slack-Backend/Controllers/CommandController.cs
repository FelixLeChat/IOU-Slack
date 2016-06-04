using IOU_Slack_Backend.Dtos;
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
        public IHttpActionResult UOI(string data)
        {
            var commandRequest = JsonConvert.DeserializeObject<CommandRequest>(data);

            CommandHandler commandHandler = new CommandHandler(commandRequest, CommandType.UOI);

            if (!commandHandler.ValidateCommand())
            {
                return this.Unauthorized();
            }

            var commandResponse = commandHandler.Execute();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("UOI Response!!");

            return this.ResponseMessage(response);
        }

        [HttpPost]
        [Route("iou")]
        public IHttpActionResult IOU(string data)
        {
            return this.Ok("IOU Response!!");
        }
    }
}
