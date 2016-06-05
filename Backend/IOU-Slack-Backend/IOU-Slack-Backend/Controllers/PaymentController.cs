using IOU_Slack_Backend.Services;
using System.Web.Http;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        [HttpPost]
        [Route("{eventId}/{userId}")]
        public IHttpActionResult ConfirmPayment(int eventId, string userId, double amount)
        {
            new DebtService().ReimburseDebt(eventId, userId, amount);

            return this.Ok();
        }
    }
}