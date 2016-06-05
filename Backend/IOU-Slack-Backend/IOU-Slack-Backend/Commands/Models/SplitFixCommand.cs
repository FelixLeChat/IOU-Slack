using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Models;
using IOU_Slack_Backend.Services;
using System.Collections.Specialized;
using System.Net;

namespace IOU_Slack_Backend.Commands.Models
{
    public class SplitFixCommand : Command
    {
        public SplitFixCommand(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.SubscribeToEvent;
        }

        public override void Execute()
        {
            var endpoint = "https://ioubot.herokuapp.com/api/close-registration";

            var eventService = new EventService();

            var eventId = eventService
                .GetEventByCreatorId(this.Parameters[0], CommandRequest.User_ID).EventID;

            SplitFixModel model = new SplitFixModel()
            {
                EventID = eventId,
                Amount = float.Parse(this.Parameters[1])
            };

            WebClient client = new WebClient();

            string function = "";
            EventService service = new EventService();
            if (this.Type == CommandType.Fix)
            {
                function = "FIX_EVENT_IOU " + model.EventID + " " + model.Amount;
                service.Fix(model);

            }
            else if (this.Type == CommandType.Split)
            {
                function = "SPLIT_EVENT_IOU " + model.EventID + " " + model.Amount;
                service.Split(model);
            }

            var response = client.UploadValues(endpoint, "POST", new NameValueCollection() {
               {"token", "xoxp-48206941781-48203038320-48270725746-ed4777abef"},
               {"as_user", "true"},
               {"channel", "@ioubot" },
               {"text", function}
           });

        }
    }
}