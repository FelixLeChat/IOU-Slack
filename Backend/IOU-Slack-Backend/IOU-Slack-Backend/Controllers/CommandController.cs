using System.Net;
using System.Net.Http;
using System.Web.Http;
using IOU_Slack_Backend.Commands;
using IOU_Slack_Backend.Dtos;
using Newtonsoft.Json;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/command")]
    public class CommandController : ApiController
    {
        [HttpPost]
        [Route("uoi")]
        public IHttpActionResult UOI(CommandRequest commandRequest)
        {
            CommandHandler commandHandler = new CommandHandler(commandRequest, CommandType.UOI);

            if (!commandHandler.ValidateCommand())
            {
                //return this.Unauthorized();
            }

            var commandResponse = commandHandler.Execute();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("UOI Response!!");

            return this.ResponseMessage(response);
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
