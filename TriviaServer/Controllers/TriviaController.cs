using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviaController : ControllerBase
    {
        // GET: api/<TriviaController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            List<Question> result;
            DatabaseManager manager = new DatabaseManager();
            result = manager.GetQuestions().Result;
            return result;
        }

        // GET api/<TriviaController>/5
        [HttpGet("{id}")]
        public IEnumerable<Question> Get(string id)
        {
            List<Question> result;
            DatabaseManager manager = new DatabaseManager();
            result = manager.GetQuestion(id).Result;
            return result;
        }

    }
}
