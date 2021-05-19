using DigiClassroom.Infrastructure.Models;
using DigiClassroom.Web.Controllers.ClassroomCt.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiClassroom.Web.Controllers.ClassroomCt
{
    public interface IClassroomController
    {
        IEnumerable<ClassroomDetail> FindClassrooms();
        Task<ActionResult<ClassroomDetail>> FindClassroom(Guid id);
        Task<IActionResult> Save(ClassroomForm form);
    }
}
