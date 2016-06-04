using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Services;

namespace IOU_Slack_Backend.Commands.Models
{
    public class CloseRegistrationEvent : Command
    {
        public CloseRegistrationEvent(string parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.SubscribeToEvent;
        }

        public override void Execute()
        {
            var endpoint = "https://ioubot.herokuapp.com/api/close-registration";

            var eventService = new EventService();

            var eventId = eventService
                .getEventByAdminId(this.Parameters, CommandRequest.User_ID).Id;

            string e = "{ userId:"+CommandRequest.User_ID+"userName:"+CommandRequest.User_Name+"eventId:"+eventId+"}";

            HttpRequestHelper.PostObjectAsync(endpoint, e);

            eventService.CloseEvent(eventId.ToString());
        }
    }
}