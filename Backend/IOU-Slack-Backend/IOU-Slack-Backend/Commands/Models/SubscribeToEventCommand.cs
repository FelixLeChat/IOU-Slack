using IOU_Slack_Backend.Dtos;

namespace IOU_Slack_Backend.Commands.Models
{
    public class SubscribeToEventCommand : Command
    {
        public SubscribeToEventCommand(string parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.SubscribeToEvent;
        }

        public override void Execute()
        {
            //var endpoint = "https://ioubot.herokuapp.com/api/create-event";

            //var e = new Event
            //{
            //    ChannelId = this.CommandRequest.Channel_ID,
            //    ChannelName = this.CommandRequest.Channel_Name,
            //    CreatorUserId = this.CommandRequest.User_ID,
            //    CreatorUsername = this.CommandRequest.User_Name,
            //    EventName = this.Parameters
            //};

            //HttpRequestHelper.PostObjectAsync(endpoint, e);
        }
    }
}