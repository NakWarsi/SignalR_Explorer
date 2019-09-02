using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_ServerTesting.SignalRHubManager;

namespace SignalR_ServerTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IHubContext<SignalRHub> HubTester;
        public ValuesController(IHubContext<SignalRHub> hub)
        {
            HubTester = hub;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            
            await  HubTester.Clients.All.SendAsync("ReceiveServerMessage","ABC","ZYXXXX");
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
