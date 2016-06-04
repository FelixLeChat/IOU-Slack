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
        [Route("iou")]
        public CommandResponse IOU(CommandRequest commandRequest)
        {
            CommandHandler commandHandler = new CommandHandler(commandRequest);

            if (!commandHandler.ValidateCommand())
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            var commandResponse = commandHandler.Execute();

            return commandResponse;
        }
    }
}
