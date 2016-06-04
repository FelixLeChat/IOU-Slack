using System.Web.Http;
using IOU_Slack_Backend.Services;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        private static EventService EventService { get; } = new EventService();

        [HttpPost]
        [Route("create")]
        public void CreateEvent(Event newEvent)
        {
            EventService.Create(newEvent);
        }
    }
}