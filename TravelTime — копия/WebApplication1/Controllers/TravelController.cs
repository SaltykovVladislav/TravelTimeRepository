using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public TravelController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Travel> Travel = Context.Travels.ToList();
            return Ok(Travel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Travel? Travel = Context.Travels.Where(x => x.Idtravel == id).FirstOrDefault();
            if (Travel == null)
            {
                return BadRequest("Not found");
            }
            return Ok(Travel);
        }

        [HttpPost]
        public IActionResult Add(Travel Travel)
        {
            Context.Travels.Add(Travel);
            Context.SaveChanges();
            return Ok(Travel);
        }

        [HttpPut]
        public IActionResult Update(Travel Travel)
        {
            Context.Travels.Update(Travel);
            Context.SaveChanges();
            return Ok(Travel);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Travel? Travel = Context.Travels.Where(x => x.Idtravel == id).FirstOrDefault();
            if (Travel == null)
            {
                return BadRequest("Not found");
            }
            Context.Travels.Remove(Travel);
            Context.SaveChanges();
            return Ok();
        }
    }


}
