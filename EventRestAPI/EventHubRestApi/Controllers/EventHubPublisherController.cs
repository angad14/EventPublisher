using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventHubRestApi.Interfaces;
using System.Net.Http;
using EventHubRestApi.Classes;

namespace EventHubRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventHubPublisherController : ControllerBase
    {

        private readonly IEventHub _eventHub;

        //public EventHubPublisherController(IEventHub eventHub)
        //{
        //    _eventHub = eventHub;
        //}

        public EventHubPublisherController()
        {
            _eventHub = new EventHub();
        }
        // GET: api/EventHubPublisher
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Temp1", "Temp2" };
        }

        //// GET: api/EventHubPublisher/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/EventHubPublisher
        [HttpPost]
        public ActionResult<string> Post(string value)
        {
            var result = _eventHub.SendMessage(value).Result;
            return Ok(result);
        }

        // PUT: api/EventHubPublisher/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
