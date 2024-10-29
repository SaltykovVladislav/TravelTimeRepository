using BuisinessLogic.Interfaces;
//using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {/*
        public TravelTimeContext Context { get; }

        public UserController(TravelTimeContext context)
        {
            Context = context;
        }

        [HttpGet("0")]
        public IActionResult GetAll()
        {
            List<User> User = Context.Users.ToList();
            return Ok(User);
        }
        */

        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Ok("1");
            try
            {
                //int b = 0;
                // int a= 5/b;
                return Ok(await _userService.GetAll());
            }
            catch (Exception ex)
            {
                //return BadRequest("err");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.Create(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }*/
    }
}