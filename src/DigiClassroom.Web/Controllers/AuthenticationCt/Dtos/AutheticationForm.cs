using System.ComponentModel.DataAnnotations;

namespace DigiClassroom.Web.Controllers.AuthenticationCt.Dtos
{
    public class AutheticationForm
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}