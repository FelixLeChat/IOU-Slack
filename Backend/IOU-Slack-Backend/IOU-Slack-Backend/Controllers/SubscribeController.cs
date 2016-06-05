using System;
using System.Web.Http;
using IOU_Slack_Backend.Models;
using IOU_Slack_Backend.Services;

namespace IOU_Slack_Backend.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/subscribe")]
    public class SubscribeController : ApiController
    {
        private static EventSubscriptionService EventSubscriptionService { get; set; } = new EventSubscriptionService();

        [HttpPost]
        [Route("subscribe")]
        public void Subscribe(SubscribeModel subscribeModel)
        {
            EventSubscriptionService.Subscribe(subscribeModel);
        }

        [HttpPost]
        [Route("unsubscribe")]
        public void Unsubcribe(SubscribeModel subscribeModel)
        {
        }
    }
}