using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Helper;
using IOU_Slack_Backend.Models;
using IOU_Slack_Backend.Services;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace IOU_Slack_Backend.Commands.Models
{
    public class SplitFixCommand : Command
    {
        public SplitFixCommand(string[] parameters, CommandRequest commandRequest, CommandType commandType) : base(parameters, commandRequest)
        {
            this.Type = commandType;
        }

        public override void Execute()
        {
            var endpoint = "https://slack.com/api/chat.postMessage";

            var eventService = new EventService();

            var eventId = eventService
                .GetEventByCreatorId(this.Parameters[0], CommandRequest.User_ID).EventID;

            SplitFixModel model = new SplitFixModel()
            {
                EventID = eventId,
                Amount = double.Parse(this.Parameters[1])
            };

            WebClient client = new WebClient();
            string text = "";
            EventService service = new EventService();

            if (this.Type == CommandType.Fix)
            {
                var users = service.Split(model);
                var userArray = string.Join(",", users);

                text = string.Format("FIX_EVENT_IOU {0} {1} {2} {3} [{4}]", model.Amount, this.Parameters[0], this.Parameters[2], CommandRequest.Channel_ID, userArray);
            }

            else if (this.Type == CommandType.Split)
            {
                var users = service.Split(model);
                var userArray = string.Join(",", users);

                text = string.Format("SPLIT_EVENT_IOU {0} {1} {2} {3} [{4}]", model.Amount, this.Parameters[0], this.Parameters[2], CommandRequest.Channel_ID, userArray);
            }

            var response = client.UploadValues(endpoint, "POST", new NameValueCollection() {
                {"token", "xoxp-48206941781-48203038320-48270725746-ed4777abef"},
                {"as_user", "true"},
                {"channel", "@ioubot" },
                {"text", text}
            });

            this.CommandResponse.Text = "Event is now active!";
        }
    }
}