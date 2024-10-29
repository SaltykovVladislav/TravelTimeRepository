using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
//using Domain.Wrapper;
using Domain.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactListPmController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public ContactListPmController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ContactListPm> ContactListPm = Context.ContactListPms.ToList();
            return Ok(ContactListPm);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ContactListPm? ContactListPm = Context.ContactListPms.Where(x => x.Idusers == id).FirstOrDefault();
            if (ContactListPm == null)
            {
                return BadRequest("Not found");
            }
            return Ok(ContactListPm);
        }

        [HttpPost]
        public IActionResult Add(ContactListPm ContactListPm)
        {
            Context.ContactListPms.Add(ContactListPm);
            Context.SaveChanges();
            return Ok(ContactListPm);
        }

        [HttpPut]
        public IActionResult Update(ContactListPm ContactListPm)
        {
            Context.ContactListPms.Update(ContactListPm);
            Context.SaveChanges();
            return Ok(ContactListPm);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ContactListPm? ContactListPm = Context.ContactListPms.Where(x => x.Idusers == id).FirstOrDefault();
            if (ContactListPm == null)
            {
                return BadRequest("Not found");
            }
            Context.ContactListPms.Remove(ContactListPm);
            Context.SaveChanges();
            return Ok();
        }
    }


}
