using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using BusinessLogic.Services;
using Domain.Interfaces.Service;
//using Domain.Wrapper;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public TravelTimeContext Context { get; }

        public GroupController(TravelTimeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Group group)
        {
            await _groupService.Create(group);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Group group)
        {
            await _groupService.Update(group);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupService.Delete(id);
            return Ok();
        }
    }
}
