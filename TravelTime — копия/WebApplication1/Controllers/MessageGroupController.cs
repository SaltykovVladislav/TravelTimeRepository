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
    public class MessageGroupController : ControllerBase
    {

        public TravelTimeContext Context { get; }

        public MessageGroupController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<MessageGroup> MessageGroup = Context.MessageGroups.ToList();
            return Ok(MessageGroup);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int idgroup,int idmessage)
        {
            MessageGroup? MessageGroup = Context.MessageGroups.Where(x => (x.Idgroup == idgroup && x.Idmessage==idmessage)).FirstOrDefault();
            if (MessageGroup == null)
            {
                return BadRequest("Not found");
            }
            return Ok(MessageGroup);
        }

        [HttpPost]
        public IActionResult Add(MessageGroup MessageGroup)
        {
            Context.MessageGroups.Add(MessageGroup);
            Context.SaveChanges();
            return Ok(MessageGroup);
        }

        [HttpPut]
        public IActionResult Update(MessageGroup MessageGroup)
        {
            Context.MessageGroups.Update(MessageGroup);
            Context.SaveChanges();
            return Ok(MessageGroup);
        }

        [HttpDelete("{group}")]
        public IActionResult Delete(int idgroup)
        {
            MessageGroup? MessageGroup = Context.MessageGroups.Where(x => x.Idgroup == idgroup ).FirstOrDefault();
            if (MessageGroup == null)
            {
                return BadRequest("Not found");
            }
            Context.MessageGroups.Remove(MessageGroup);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{message}")]
        public IActionResult Delete(int idgroup, int idmessage)
        {
            MessageGroup? MessageGroup = Context.MessageGroups.Where(x => (x.Idgroup == idgroup && x.Idmessage == idmessage)).FirstOrDefault();
            if (MessageGroup == null)
            {
                return BadRequest("Not found");
            }
            Context.MessageGroups.Remove(MessageGroup);
            Context.SaveChanges();
            return Ok();
        }
    }


}
