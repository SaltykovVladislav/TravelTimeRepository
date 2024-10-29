using ConsoleApp1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vladislav_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public TravelContext Context { get; }

        public UsersController(TravelContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PasswordAndUserName> users = Context.PasswordAndUserNames.ToList();
                return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PasswordAndUserName? userName = Context.PasswordAndUserNames.Where(x => x.Id == id).FirstOrDefault();
            if (userName == null)
            {
                return Ok(userName);
            }
            return Ok(userName);
        }
    }
}
