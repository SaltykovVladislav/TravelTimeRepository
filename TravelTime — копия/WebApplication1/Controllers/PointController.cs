using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public PointController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Point> Point = Context.Points.ToList();
            return Ok(Point);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Point? Point = Context.Points.Where(x => x.Idpoint == id).FirstOrDefault();
            if (Point == null)
            {
                return BadRequest("Not found");
            }
            return Ok(Point);
        }

        [HttpPost]
        public IActionResult Add(Point Point)
        {
            Context.Points.Add(Point);
            Context.SaveChanges();
            return Ok(Point);
        }

        [HttpPut]
        public IActionResult Update(Point Point)
        {
            Context.Points.Update(Point);
            Context.SaveChanges();
            return Ok(Point);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Point? Point = Context.Points.Where(x => x.Idpoint == id).FirstOrDefault();
            if (Point == null)
            {
                return BadRequest("Not found");
            }
            Context.Points.Remove(Point);
            Context.SaveChanges();
            return Ok();
        }
    }


}
