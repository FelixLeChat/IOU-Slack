using IOU_Slack_Backend.Dtos;
using IOU_Slack_Backend.Helper;
using System.Collections.Specialized;
using System.Net;

namespace IOU_Slack_Backend.Commands.Models
{
    public class CreateEventCommand : Command
    {
        public CreateEventCommand(string[] parameters, CommandRequest commandRequest) : base(parameters, commandRequest)
        {
            this.Type = CommandType.CreateEvent;
        }

        public override void Execute()
        {
            var endpoint = "https://slack.com/api/chat.postMessage";
            var e = new Event
            {
                ChannelID = this.CommandRequest.Channel_ID,
                ChannelName = this.CommandRequest.Channel_Name,
                CreatorID = this.CommandRequest.User_ID,
                CreatorUsername = this.CommandRequest.User_Name,
                Name = this.Parameters[0]
            };


            WebClient client = new WebClient();

            var response = client.UploadValues(endpoint, "POST", new NameValueCollection() {
               {"token", "xoxp-48206941781-48203038320-48270725746-ed4777abef"},
               {"as_user", "true"},
               {"channel", "@ioubot" },
               {"text", "CREATE_EVENT_IOU " + e.ChannelID + " " + e.ChannelName + " " + e.CreatorID + " " + e.CreatorUsername +  " " + e.Name }
           });

            //Channel channel = new Channel();
            //JsonConvert.PopulateObject(response.ToString(), channel);


            //var e = "{'token':'xoxb-48267464898-hkDEJNgqxAvuXspZYdEKB8OF','as_user':'false','channel':'@ioubot',text:'CREATE_EVENT_IOU name name felix name name'}";

           //var response =   HttpRequestHelper.PostObjectAsync(endpoint, e);
           
        }
    }
}