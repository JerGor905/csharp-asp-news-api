using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly WebContext _webContext;

        public NewsController(WebContext webContext)
        {
            _webContext = webContext;
        }

        [HttpGet]
        public IEnumerable<News> Get()
        {
            return _webContext.News;
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
