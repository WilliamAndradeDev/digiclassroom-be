using DigiClassroom.ApplicationCore.Services.AutheticationSv;
using DigiClassroom.Web.Controllers.AuthenticationCt.Dtos;
using DigiClassroom.Web.SecurityConfig.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DigiClassroom.Web.Controllers.AuthenticationCt
{
    [ApiController]
    [Route("/v1/[Controller]")]
    public class AuthenticationController : ControllerBase, IAuthenticationController
    {

        private ITokenService _tokenService;
        private IAuthenticationService _authenticationService;

        public AuthenticationController(ITokenService tokenService, IAuthenticationService authenticationService)
        {
            _tokenService = tokenService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDto>> AuthenticateUser(AutheticationForm form)
        {
            var user = await _authenticationService
                                        .AuthenticateUser(form.Username, form.Password);
            if (user == null)
                return Unauthorized(new { message = "Usuário ou Senha inválidos. Tente novamente." });

            string token = _tokenService.GenerateToken(user);
            return new TokenDto(token: token);
        }

    }
}