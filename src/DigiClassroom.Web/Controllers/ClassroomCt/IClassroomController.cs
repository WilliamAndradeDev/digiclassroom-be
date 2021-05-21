using DigiClassroom.Web.Controllers.ClassroomCt.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigiClassroom.Web.Controllers.ClassroomCt
{
    public interface IClassroomController
    {
        Task<ActionResult<ClassroomDetail>> FindClassroom(Guid id);
        Task<IActionResult> Save(ClassroomForm form,string tokenRaw);
    }
}
