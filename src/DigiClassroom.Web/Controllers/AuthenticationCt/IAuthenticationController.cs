using System.Threading.Tasks;
using DigiClassroom.Web.Controllers.AuthenticationCt.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DigiClassroom.Web.Controllers.AuthenticationCt
{
    public interface IAuthenticationController
    {
         Task<ActionResult<TokenDto>> CreateToken(AutheticationForm form);
    }
}