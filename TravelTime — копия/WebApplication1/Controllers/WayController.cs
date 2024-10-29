using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
//using Domain.Wrapper;
using DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WayController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public WayController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Way> Way = Context.Ways.ToList();
            return Ok(Way);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Way? Way = Context.Ways.Where(x => x.Idway == id).FirstOrDefault();
            if (Way == null)
            {
                return BadRequest("Not found");
            }
            return Ok(Way);
        }

        [HttpPost]
        public IActionResult Add(Way Way)
        {
            Context.Ways.Add(Way);
            Context.SaveChanges();
            return Ok(Way);
        }

        [HttpPut]
        public IActionResult Update(Way Way)
        {
            Context.Ways.Update(Way);
            Context.SaveChanges();
            return Ok(Way);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Way? Way = Context.Ways.Where(x => x.Idway == id).FirstOrDefault();
            if (Way == null)
            {
                return BadRequest("Not found");
            }
            Context.Ways.Remove(Way);
            Context.SaveChanges();
            return Ok();
        }
    }
}
