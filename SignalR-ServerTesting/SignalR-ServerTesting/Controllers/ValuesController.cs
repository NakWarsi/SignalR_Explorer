using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SignalR_ServerTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private HubTest HubTester = new HubTest();
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            HubTester.SendMethod("abcdeg");
            return new string[] { "value1", "value2" };

        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            HubTester.SendMethod(value);
        }
    }
}
