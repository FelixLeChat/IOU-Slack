using System.Linq;
using System.Web.Mvc;
using IOU_Slack_Backend.Context;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : Controller
    {
        [HttpGet]
        public string Test()
        {
            return "OK :D!";
        }
    }
}