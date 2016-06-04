using IOUCommands.Dtos;
using IOUCommands.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace IOUCommands.Controllers
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
            response.Content = new StringContent(commandResponse);

            return this.ResponseMessage(response);
        }
    }
}
