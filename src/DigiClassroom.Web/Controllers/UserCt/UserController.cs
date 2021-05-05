using System;
using System.Threading.Tasks;
using DigiClassroom.ApplicationCore.Services.UserSV;
using DigiClassroom.Web.Controllers.UserCt.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigiClassroom.Web.Controllers.UserCt
{
    [ApiController]
    [Route("/v1/[Controller]")]
    public class UserController : ControllerBase, IUserController
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Create(UserForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(form.toUser());
                return CreatedAtAction("FindUser", new { id = result.Id }, new UserDto(result));
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> FindUser(Guid id)
        {
            var result= await _userService.FindUser(id);
            if(result!=null)
                return new UserDto(result);
            else
                return NotFound();
        }
    }
}