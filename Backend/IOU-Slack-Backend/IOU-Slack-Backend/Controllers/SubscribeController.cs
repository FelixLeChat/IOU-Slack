using System;
using System.Web.Http;

namespace IOU_Slack_Backend.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/subscribe")]
    public class SubscribeController : ApiController
    {
        [HttpPost]
        [Route("create")]
        public void CreateEvent(Event newEvent)
        {
            throw new NotImplementedException();
        }
    }
}