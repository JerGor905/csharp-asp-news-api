using Microsoft.AspNetCore.Mvc;
using NewsAPI.Dtos;
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
        public IEnumerable<NewsDto> Get()
        {
            IEnumerable<NewsDto> result = from n in _webContext.News
                                          select new NewsDto
                                          {
                                              NewsId = n.NewsId,
                                              Title = n.Title,
                                              Content = n.Content,
                                              StartDateTime = n.StartDateTime,
                                              EndDateTime = n.EndDateTime,
                                              Click = n.Click
                                          };

            return result;
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public NewsDto Get(Guid id)
        {
            NewsDto result = (from n in _webContext.News
                              where n.NewsId == id
                              select new NewsDto
                              {
                                  NewsId = n.NewsId,
                                  Title = n.Title,
                                  Content = n.Content,
                                  StartDateTime = n.StartDateTime,
                                  EndDateTime = n.EndDateTime,
                                  Click = n.Click
                              }).SingleOrDefault();

            return result;
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
