using IOU_Slack_Backend.Backend_Models;
using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Services;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            // var list = ....

            EventSubscriptionService eventSubscriptionService = new EventSubscriptionService();
            EventService eventService = new EventService();
            DebtService debtService = new DebtService();

            var actualEvent = eventService.GetEventByCreatorId(this.Parameters[0], this.CommandRequest.User_ID);

            List<Debt> list = debtService.GetUnpaidDebts(actualEvent.EventID);

            WebClient client = new WebClient();

            foreach (Debt debt in list)
            {
                var response = client.UploadValues("https://slack.com/api/reminders.add", "POST", new NameValueCollection() {
                   { "token", "xoxp-48206941781-48203038320-48270725746-ed4777abef"},
                   {"Text", string.Format("You need to pay {0} to {1} before the {2}",debt.AmountDue,actualEvent.CreatorUsername,actualEvent.PaymentDeadline) },
                   {"time", this.Parameters[1]},
                   {"user", eventSubscriptionService.GetUserNameById(debt.UserID, debt.EventID)}
                });
            }
        }
    }
}