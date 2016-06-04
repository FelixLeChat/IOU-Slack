using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Services;

namespace IOU_Slack_Backend.Commands.Models
{
    public class CloseRegistrationEvent : Command
    {
        public CloseRegistrationEvent(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.SubscribeToEvent;
        }

        public override void Execute()
        {
            var endpoint = "https://ioubot.herokuapp.com/api/close-registration";

            var eventService = new EventService();

            var eventId = eventService
                .GetEventByCreatorId(this.Parameters[0], CommandRequest.User_ID).Id;

            var e = new Event
            {
                CreatorUserId = CommandRequest.User_ID,
                CreatorUsername = CommandRequest.User_Name,
                Id = eventId
            };

            HttpRequestHelper.PostObjectAsync(endpoint, e);

            eventService.CloseEvent(eventId.ToString());
        }
    }
}