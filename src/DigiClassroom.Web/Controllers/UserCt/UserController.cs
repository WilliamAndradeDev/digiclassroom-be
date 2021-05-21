using DigiClassroom.ApplicationCore.Services.UserSv;
using DigiClassroom.Web.Controllers.ClassroomCt.Dtos;
using DigiClassroom.Web.Controllers.UserCt.Dtos;
using DigiClassroom.Web.ExceptionHdl.ErrorModels;
using DigiClassroom.Web.ExceptionHdl.Extensions;
using DigiClassroom.Web.SecurityConfig.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigiClassroom.Web.Controllers.UserCt
{
    [ApiController]
    [Route("/v1/[Controller]")]
    public class UserController : ControllerBase, IUserController
    {

        private IUserService _userService;
        private ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Create(UserForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.Create(form.toUser());
                    return CreatedAtAction("FindUser", new { id = result.Id }, new UserDto(result));
                }
                catch (DbUpdateException)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                                                new ErrorResponse("Já existe um usuário com esse Login.", 409));
                }
            }
            return BadRequest(new ErrorResponse(ModelState.GetErrorsEnumerated()));
        }

        [HttpGet("Classrooms")]
        [Authorize(Roles = "student,teacher")]
        public async Task<IEnumerable<ClassroomDetail>> GetUserClassrooms([FromHeader(Name = "Authorization")]
                                                                                                 string tokenRaw)
        {
            var user = await _userService.
                                        FindUserWithClassroomsByUsernameAsync(_tokenService.GetUserName(tokenRaw));
            return user.Classrooms.Select(c => new ClassroomDetail(c));
        }

    }
}