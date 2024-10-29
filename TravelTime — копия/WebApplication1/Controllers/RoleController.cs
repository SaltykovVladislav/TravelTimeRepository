using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces.Service;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _roleService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Role role)
        {
            await _roleService.Create(role);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            await _roleService.Update(role);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
    }
}
/*using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Domain.Interfaces.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _roleService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Role role)
        {
            await _roleService.Create(role);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            await _roleService.Update(role);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
    }
}
*/