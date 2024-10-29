using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesUserController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public PreferencesUserController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PreferencesUser> PreferencesUser = Context.PreferencesUsers.ToList();
            return Ok(PreferencesUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PreferencesUser? PreferencesUser = Context.PreferencesUsers.Where(x => x.Idpreferences == id).FirstOrDefault();
            if (PreferencesUser == null)
            {
                return BadRequest("Not found");
            }
            return Ok(PreferencesUser);
        }

        [HttpPost]
        public IActionResult Add(PreferencesUser PreferencesUser)
        {
            Context.PreferencesUsers.Add(PreferencesUser);
            Context.SaveChanges();
            return Ok(PreferencesUser);
        }

        [HttpPut]
        public IActionResult Update(PreferencesUser PreferencesUser)
        {
            Context.PreferencesUsers.Update(PreferencesUser);
            Context.SaveChanges();
            return Ok(PreferencesUser);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            PreferencesUser? PreferencesUser = Context.PreferencesUsers.Where(x => x.Idpreferences == id).FirstOrDefault();
            if (PreferencesUser == null)
            {
                return BadRequest("Not found");
            }
            Context.PreferencesUsers.Remove(PreferencesUser);
            Context.SaveChanges();
            return Ok();
        }
    }


}
