using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public NewsController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<News> News = Context.News.ToList();
            return Ok(News);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            News? News = Context.News.Where(x => x.Idnews == id).FirstOrDefault();
            if (News == null)
            {
                return BadRequest("Not found");
            }
            return Ok(News);
        }

        [HttpPost]
        public IActionResult Add(News News)
        {
            Context.News.Add(News);
            Context.SaveChanges();
            return Ok(News);
        }

        [HttpPut]
        public IActionResult Update(News News)
        {
            Context.News.Update(News);
            Context.SaveChanges();
            return Ok(News);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            News? News = Context.News.Where(x => x.Idnews == id).FirstOrDefault();
            if (News == null)
            {
                return BadRequest("Not found");
            }
            Context.News.Remove(News);
            Context.SaveChanges();
            return Ok();
        }
    }


}
