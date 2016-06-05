using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Services;
using System.Collections.Specialized;
using System.Net;

namespace IOU_Slack_Backend.Commands.Models
{
    public class PayForCommand : Command
    {
        public PayForCommand(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.PayFor;
        }

        public override void Execute()
        {
            var eventName = this.Parameters[1];
            var userName = this.CommandRequest.User_Name;
            var userId = this.CommandRequest.User_ID;
            var channelId = this.CommandRequest.Channel_ID;

            var e = new EventService()
                .GetByName(eventName, channelId);

            var endpoint = "https://slack.com/api/chat.postMessage";

            WebClient client = new WebClient();

            var response = client.UploadValues(endpoint, "POST", new NameValueCollection() {
                {"token", "xoxp-48206941781-48203038320-48270725746-ed4777abef"},
                {"as_user", "true"},
                {"channel", "@ioubot" },
                {"text", string.Format("PAY_EVENT_IOU {0} {1} {2} {3} {4} {5}", this.Parameters[0], eventName, e.ID, userName, userId, e.CreatorUsername)}
            });

            if (this.Parameters[2] == "paypal")
            {
                var paypalLink = "https://www.paypal.me/felixlrc/" + this.Parameters[0];

                this.CommandResponse.Text = string.Format("Use the following <{0}|payment link> to pay {1} back!", paypalLink, e.CreatorUsername);
            }
            else
            {
                this.CommandResponse.Text = string.Format("{0} thanks you for paying him back!", e.CreatorUsername);
            }
        }
    }
}