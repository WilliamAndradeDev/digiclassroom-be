using System.ComponentModel.DataAnnotations;

namespace DigiClassroom.Web.Controllers.AuthenticationCt.Dtos
{
    public class AutheticationForm
    {
        [Required(ErrorMessage = "O campo Nome precisa ser preenchido.")]
        [MinLength(17, ErrorMessage = "O campo Nome deve ter no mínimo {1}.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "O campo Senha precisa ser preenchido.")]
        [MinLength(8, ErrorMessage = "O campo Senha deve ter no mínimo {1}.")]
        public string Password { get; set; }
    }
}