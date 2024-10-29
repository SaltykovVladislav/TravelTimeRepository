using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingNewsUserController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public RatingNewsUserController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<RatingNewsUser> RatingNewsUser = Context.RatingNewsUsers.ToList();
            return Ok(RatingNewsUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            RatingNewsUser? RatingNewsUser = Context.RatingNewsUsers.Where(x => x.Idnews == id).FirstOrDefault();
            if (RatingNewsUser == null)
            {
                return BadRequest("Not found");
            }
            return Ok(RatingNewsUser);
        }

        [HttpPost]
        public IActionResult Add(RatingNewsUser RatingNewsUser)
        {
            Context.RatingNewsUsers.Add(RatingNewsUser);
            Context.SaveChanges();
            return Ok(RatingNewsUser);
        }

        [HttpPut]
        public IActionResult Update(RatingNewsUser RatingNewsUser)
        {
            Context.RatingNewsUsers.Update(RatingNewsUser);
            Context.SaveChanges();
            return Ok(RatingNewsUser);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            RatingNewsUser? RatingNewsUser = Context.RatingNewsUsers.Where(x => x.Idnews == id).FirstOrDefault();
            if (RatingNewsUser == null)
            {
                return BadRequest("Not found");
            }
            Context.RatingNewsUsers.Remove(RatingNewsUser);
            Context.SaveChanges();
            return Ok();
        }
    }


}
