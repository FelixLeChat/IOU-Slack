using IOU_Slack_Backend.Backend_Models;
using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Services;

namespace IOU_Slack_Backend.Commands.Models
{
    public class SubscribeToEventCommand : Command
    {
        public SubscribeToEventCommand(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.SubscribeToEvent;
        }

        public override void Execute()
        {
            var userId = this.CommandRequest.User_ID;
            var eventName = this.Parameters[0];
            var channelId = this.CommandRequest.Channel_ID;

            var eventId = new EventService()
                .GetByName(eventName, channelId).Id;

            new EventSubscriptionService().Create(
                new EventSubscription { EventId = eventId, UserId = userId }
            );
        }
    }
}