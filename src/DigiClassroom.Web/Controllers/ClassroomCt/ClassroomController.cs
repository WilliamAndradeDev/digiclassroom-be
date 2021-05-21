using DigiClassroom.ApplicationCore.Services.ClassroomSv;
using DigiClassroom.Web.Controllers.ClassroomCt.Dtos;
using DigiClassroom.Web.ExceptionHdl.ErrorModels;
using DigiClassroom.Web.ExceptionHdl.Extensions;
using DigiClassroom.Web.SecurityConfig.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigiClassroom.Web.Controllers.ClassroomCt
{
    [ApiController]
    [Route("/v1/[Controller]")]
    public class ClassroomController : ControllerBase, IClassroomController
    {

        private IClassroomService _classroomService;
        private ITokenService _tokenService;

        public ClassroomController(IClassroomService classroomService, ITokenService tokenService)
        {
            _classroomService = classroomService;
            _tokenService = tokenService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "teacher")]
        public async Task<ActionResult<ClassroomDetail>> FindClassroom(Guid id)
        {
            var result = await _classroomService.FindClassroom(id);
            if (result != null)
                return new ClassroomDetail(result);
            else
                return NotFound(new ErrorResponse("Não existe uma Turma com esse identificador.", 404));
        }

        [HttpPost]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Save(ClassroomForm form,
                                                [FromHeader(Name ="Authorization")] string tokenRaw)
        {
            if (ModelState.IsValid)
            {
                var result = await _classroomService.Save(form.ToClassroom(),
                                                            _tokenService.GetUserName(tokenRaw));
                return CreatedAtAction("FindClassroom", new { Id = result.Id }, new ClassroomDetail(result));
            }
            return BadRequest(new ErrorResponse(ModelState.GetErrorsEnumerated()));
        }
    }
}
