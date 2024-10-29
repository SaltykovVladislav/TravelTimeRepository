using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryVisitUserController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public StoryVisitUserController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<StoryVisitUser> StoryVisitUser = Context.StoryVisitUsers.ToList();
            return Ok(StoryVisitUser);
        }

        [HttpGet("{DataUserAndPointId}")]
        public IActionResult GetById(int idUsers, int idPoint)
        {
            StoryVisitUser? StoryVisitUser = Context.StoryVisitUsers.Where(x => (x.Idusers == idUsers && x.Idpoint == idPoint)).FirstOrDefault();
            if (StoryVisitUser == null)
            {
                return BadRequest("Not found");
            }
            return Ok(StoryVisitUser);
        }

        [HttpGet("{DataUserId}")]
        public IActionResult GetUserById(int idUsers)
        {
            StoryVisitUser? StoryVisitUser = Context.StoryVisitUsers.Where(x => x.Idusers == idUsers).FirstOrDefault();
            if (StoryVisitUser == null)
            {
                return BadRequest("Not found");
            }
            return Ok(StoryVisitUser);
        }

        [HttpGet("{DataPointId}")]
        public IActionResult GetPointById(int idPoint)
        {
            StoryVisitUser? StoryVisitUser = Context.StoryVisitUsers.Where(x => x.Idpoint == idPoint).FirstOrDefault();
            if (StoryVisitUser == null)
            {
                return BadRequest("Not found");
            }
            return Ok(StoryVisitUser);
        }

        [HttpPost]
        public IActionResult Add(StoryVisitUser StoryVisitUser)
        {
            Context.StoryVisitUsers.Add(StoryVisitUser);
            Context.SaveChanges();
            return Ok(StoryVisitUser);
        }

        [HttpPut]
        public IActionResult Update(StoryVisitUser StoryVisitUser)
        {
            Context.StoryVisitUsers.Update(StoryVisitUser);
            Context.SaveChanges();
            return Ok(StoryVisitUser);
        }

        [HttpDelete("{DataUserAndPointId}")]
        public IActionResult Delete(int idUsers, int idPoint)
        {
            StoryVisitUser? StoryVisitUser = Context.StoryVisitUsers.Where(x => (x.Idusers == idUsers && x.Idpoint == idPoint)).FirstOrDefault();
            if (StoryVisitUser == null)
            {
                return BadRequest("Not found");
            }
            Context.StoryVisitUsers.Remove(StoryVisitUser);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{DataUserId}")]
        public IActionResult DeleteUser(int idUser)
        {
            StoryVisitUser? StoryVisitUser = Context.StoryVisitUsers.Where(x => x.Idusers == idUser).FirstOrDefault();
            if (StoryVisitUser == null)
            {
                return BadRequest("Not found");
            }
            Context.StoryVisitUsers.Remove(StoryVisitUser);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{DataPointId}")]
        public IActionResult DeletePoint(int idPoint)
        {
            StoryVisitUser? StoryVisitUser = Context.StoryVisitUsers.Where(x => x.Idpoint == idPoint).FirstOrDefault();
            if (StoryVisitUser == null)
            {
                return BadRequest("Not found");
            }
            Context.StoryVisitUsers.Remove(StoryVisitUser);
            Context.SaveChanges();
            return Ok();
        }
    }


}
