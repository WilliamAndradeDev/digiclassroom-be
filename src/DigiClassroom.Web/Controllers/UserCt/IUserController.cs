using System;
using System.Threading.Tasks;
using DigiClassroom.Web.Controllers.UserCt.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DigiClassroom.Web.Controllers.UserCt
{
    public interface IUserController
    {
        Task<ActionResult<UserDto>> Create(UserForm form);
        Task<ActionResult<UserDto>> FindUser(Guid id);
    }
}