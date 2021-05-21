using DigiClassroom.Web.Controllers.ClassroomCt.Dtos;
using DigiClassroom.Web.Controllers.UserCt.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiClassroom.Web.Controllers.UserCt
{
    public interface IUserController
    {
        Task<ActionResult<UserDto>> Create(UserForm form);
        Task<IEnumerable<ClassroomDetail>> GetUserClassrooms(string tokenRaw);
    }
}