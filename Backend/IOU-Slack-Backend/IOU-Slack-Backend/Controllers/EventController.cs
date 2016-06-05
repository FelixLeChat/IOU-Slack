using System;
using System.Collections.Generic;
using System.Web.Http;
using IOU_Slack_Backend.Models;
using IOU_Slack_Backend.Services;

namespace IOU_Slack_Backend.Controllers
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        private static EventService EventService { get; } = new EventService();

        /// <summary>
        /// When the Bot get all the information on a event and the user accept the event
        /// </summary>
        /// <param name="newEvent"></param>
        [HttpPost]
        [Route(" ")]
        public void CreateEvent(Event newEvent)
        {
            EventService.Create(newEvent);
        }

        /// <summary>
        /// Return a list of the users id that are registered to the event and split the money own to evryone
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("split")]
        public List<string> SplitEvent(SplitModel splitModel)
        {
            throw new NotImplementedException();
        }
    }
}