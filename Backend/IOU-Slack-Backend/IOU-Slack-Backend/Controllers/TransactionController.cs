using System.Web.Http;
using IOU_Slack_Backend.Models;
using IOU_Slack_Backend.Services;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/transaction")]
    public class TransactionController : ApiController
    {
        private static TransactionService TransactionSErvice { get; set; } = new TransactionService();

        [HttpPost]
        [Route("paybyhand")]
        public void PayByHand(PaimentModel paimentModel)
        {
            TransactionSErvice.Pay(paimentModel, TransactionType.Hand);
        }
    }
}
