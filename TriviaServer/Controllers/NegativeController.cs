using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegativeController : ControllerBase
    {
        // GET: api/<NegativeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> values_to_return = new List<string>();
            values_to_return.Add("No");
            values_to_return.Add("Nope");
            values_to_return.Add("Hell na");

            return values_to_return;
        }

    }
}
