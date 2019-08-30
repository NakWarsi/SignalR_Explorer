using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_ServerTesting.SignalRHubManager;

namespace SignalR_ServerTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private SignalRHub HubTester = new SignalRHub();
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            await HubTester.SendMethod("abc", "xyzzzz");
            return new string[] { "value1", "value2" };
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
           // HubTester.SendMethod(value);
        }
    }
}
