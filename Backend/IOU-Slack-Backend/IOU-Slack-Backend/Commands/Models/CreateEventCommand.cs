using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Helper;

namespace IOU_Slack_Backend.Commands.Models
{
    public class CreateEventCommand : Command
    {
        public CreateEventCommand(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.CreateEvent;
        }

        public override void Execute()
        {
            var endpoint = "https://ioubot.herokuapp.com/api/create-event";

            var e = new Event
            {
                ChannelId = this.CommandRequest.Channel_ID,
                ChannelName = this.CommandRequest.Channel_Name,
                CreatorUserId = this.CommandRequest.User_ID,
                CreatorUsername = this.CommandRequest.User_Name,
                EventName = this.Parameters[0]
            };

            HttpRequestHelper.PostObjectAsync(endpoint, e);
        }
    }
}