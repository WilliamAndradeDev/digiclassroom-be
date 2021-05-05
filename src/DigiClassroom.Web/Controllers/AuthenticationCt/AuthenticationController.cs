using System.Threading.Tasks;
using DigiClassroom.Infrastructure.Repositories.UserRp;
using DigiClassroom.Web.Controllers.AuthenticationCt.Dtos;
using DigiClassroom.Web.SecurityConfig.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigiClassroom.Web.Controllers.AuthenticationCt
{
    [ApiController]
    [Route("/v1/[Controller]")]
    public class AuthenticationController : ControllerBase, IAuthenticationController
    {

        private ITokenService _tokenService;
        private IUserRepository _userRepository;

        public AuthenticationController(ITokenService tokenService,IUserRepository userRepository)
        {
            _tokenService=tokenService;
            _userRepository=userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDto>> CreateToken(AutheticationForm form)
        {
            var user= await _userRepository.
                                FindUserByUsernameAndPasswordAsync(form.Username,
                                                                    form.Password);
            if(user==null)
                return NotFound(new { message = "Usuário ou Senha inválidos. Tente novamente."});

            string token= _tokenService.GenerateToken(user);
            return new TokenDto(token:token);
        }
    }
}