using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePointController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public TypePointController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<TypePoint> TypePoint = Context.TypePoints.ToList();
            return Ok(TypePoint);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TypePoint? TypePoint = Context.TypePoints.Where(x => x.IdtypePoint == id).FirstOrDefault();
            if (TypePoint == null)
            {
                return BadRequest("Not found");
            }
            return Ok(TypePoint);
        }

        [HttpPost]
        public IActionResult Add(TypePoint TypePoint)
        {
            Context.TypePoints.Add(TypePoint);
            Context.SaveChanges();
            return Ok(TypePoint);
        }

        [HttpPut]
        public IActionResult Update(TypePoint TypePoint)
        {
            Context.TypePoints.Update(TypePoint);
            Context.SaveChanges();
            return Ok(TypePoint);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TypePoint? TypePoint = Context.TypePoints.Where(x => x.IdtypePoint == id).FirstOrDefault();
            if (TypePoint == null)
            {
                return BadRequest("Not found");
            }
            Context.TypePoints.Remove(TypePoint);
            Context.SaveChanges();
            return Ok();
        }
    }


}
