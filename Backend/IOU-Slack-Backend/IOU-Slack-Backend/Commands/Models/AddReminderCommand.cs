using IOU_Slack_Backend.Backend_Models;
using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Services;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace IOU_Slack_Backend.Commands.Models
{
    public class AddReminderCommand : Command
    {
        public AddReminderCommand(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.AddReminder;
        }

        public override void Execute()
        {
            //EventSubscriptionService eventSubscriptionService = new EventSubscriptionService();
            EventService eventService = new EventService();
            DebtService debtService = new DebtService();

            var actualEvent = eventService.GetEventByCreatorId(this.Parameters[0], this.CommandRequest.User_ID);

            List<Debt> list = debtService.GetUnpaidDebts(actualEvent.EventID);

            //foreach (Debt debt in list)
            //{
            //    var client = new WebClient();

            //    client.UploadValues(
            //        new System.Uri("https://slack.com/api/reminders.add"), "POST", new NameValueCollection() {
            //        { "token", "xoxp-48206941781-48203038320-48270725746-ed4777abef"},
            //        {"Text", string.Format("You need to pay {0} to {1} before the {2}",debt.AmountDue,actualEvent.CreatorUsername,actualEvent.PaymentDeadline) },
            //        {"time", this.Parameters[1]},
            //        {"user", eventSubscriptionService.GetUserNameById(debt.UserID, debt.EventID)}
            //    });
            //}

            //WebClient client = new WebClient();

            //var users = list.Select(d => d.UserID);
            //var userArray = string.Join(",", users);

            //var endpoint = "https://slack.com/api/chat.postMessage";
            //var response = client.UploadValues(endpoint, "POST", new NameValueCollection() {
            //    {"token", "xoxp-48206941781-48203038320-48270725746-ed4777abef"},
            //    {"as_user", "true"},
            //    {"channel", "@ioubot" },
            //    {"text", string.Format("REMINDER_EVENT_IOU {0} {1} {2} {3} {4} {5}", this.Parameters[0], )}
            //});

            this.CommandResponse.Text = string.Format("Reminder added to {0} users", list.Count);
        }
    }
}