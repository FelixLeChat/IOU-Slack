using System.Web.Http;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            return "OK :D!";
        }
    }
}