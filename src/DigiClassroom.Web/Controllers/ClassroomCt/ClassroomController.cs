using DigiClassroom.ApplicationCore.Services.ClassroomSv;
using DigiClassroom.Web.Controllers.ClassroomCt.Dtos;
using DigiClassroom.Web.ExceptionHdl.ErrorModels;
using DigiClassroom.Web.ExceptionHdl.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigiClassroom.Web.Controllers.ClassroomCt
{
    [ApiController]
    [Route("/v1/[Controller]")]
    public class ClassroomController : ControllerBase, IClassroomController
    {

        private IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "teacher")]
        public async Task<ActionResult<ClassroomDetail>> FindClassroom(Guid id)
        {
            var result = await _classroomService.FindClassroom(id);
            return new ClassroomDetail(result);
        }

        [HttpGet]
        [Authorize(Roles = "teacher")]
        public IEnumerable<ClassroomDetail> FindClassrooms()
        => _classroomService.FindClassrooms().Select(c => new ClassroomDetail(c));

        [HttpPost]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Save(ClassroomForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _classroomService.Save(form.ToClassroom());
                return CreatedAtAction("FindClassroom", new { Id = result.Id }, new ClassroomDetail(result));
            }
            return BadRequest(new ErrorResponse(ModelState.GetErrorsEnumerated()));
        }
    }
}
