using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersGroupController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public UsersGroupController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<UsersGroup> UsersGroup = Context.UsersGroups.ToList();
            return Ok(UsersGroup);
        }

        [HttpGet("{UsersAndGroupId}")]
        public IActionResult GetById(int idUsers, int idGroup)
        {
            UsersGroup? UsersGroup = Context.UsersGroups.Where(x => (x.Idusers == idUsers && x.Idgroup == idGroup)).FirstOrDefault();
            if (UsersGroup == null)
            {
                return BadRequest("Not found");
            }
            return Ok(UsersGroup);
        }

        [HttpGet("{UsersId}")]
        public IActionResult GetUsersById(int UsersId)
        {
            UsersGroup? UsersGroup = Context.UsersGroups.Where(x => x.Idusers == UsersId).FirstOrDefault();
            if (UsersGroup == null)
            {
                return BadRequest("Not found");
            }
            return Ok(UsersGroup);
        }

        [HttpGet("{GroupId}")]
        public IActionResult GetGroupById(int GroupId)
        {
            UsersGroup? UsersGroup = Context.UsersGroups.Where(x => x.Idusers == GroupId).FirstOrDefault();
            if (UsersGroup == null)
            {
                return BadRequest("Not found");
            }
            return Ok(UsersGroup);
        }

        [HttpPost]
        public IActionResult Add(UsersGroup UsersGroup)
        {
            Context.UsersGroups.Add(UsersGroup);
            Context.SaveChanges();
            return Ok(UsersGroup);
        }

        [HttpPut]
        public IActionResult Update(UsersGroup UsersGroup)
        {
            Context.UsersGroups.Update(UsersGroup);
            Context.SaveChanges();
            return Ok(UsersGroup);
        }

        [HttpDelete("{UsersAndGroupId}")]
        public IActionResult Delete(int idUsers, int idGroup)
        {
            UsersGroup? UsersGroup = Context.UsersGroups.Where(x => (x.Idusers == idUsers && x.Idgroup == idGroup)).FirstOrDefault();
            if (UsersGroup == null)
            {
                return BadRequest("Not found");
            }
            Context.UsersGroups.Remove(UsersGroup);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{UserID}")]
        public IActionResult DeleteUser(int idUsers)
        {
            UsersGroup? UsersGroup = Context.UsersGroups.Where(x => x.Idusers == idUsers).FirstOrDefault();
            if (UsersGroup == null)
            {
                return BadRequest("Not found");
            }
            Context.UsersGroups.Remove(UsersGroup);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{GroupId}")]
        public IActionResult DeleteGroup(int idGroup)
        {
            UsersGroup? UsersGroup = Context.UsersGroups.Where(x => x.Idusers == idGroup).FirstOrDefault();
            if (UsersGroup == null)
            {
                return BadRequest("Not found");
            }
            Context.UsersGroups.Remove(UsersGroup);
            Context.SaveChanges();
            return Ok();
        }
    }


}
