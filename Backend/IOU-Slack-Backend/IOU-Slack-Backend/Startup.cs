using IOU_Slack_Backend;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace IOU_Slack_Backend
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
