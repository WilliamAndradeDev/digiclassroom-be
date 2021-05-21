using System.ComponentModel.DataAnnotations;
using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.Web.Controllers.UserCt.Dtos
{
    public class UserForm
    {
        [Required(ErrorMessage = "O campo Nome precisa ser preenchido.")]
        [MinLength(5,ErrorMessage = "O campo Nome deve ter no mínimo {1}.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "O campo Senha precisa ser preenchido.")]
        [MinLength(8, ErrorMessage = "O campo Senha deve ter no mínimo {1}.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O campo Role precisa ser preenchido.")]
        [MinLength(7, ErrorMessage = "O campo Role deve ter no mínimo {1}.")]
        public string Role { get; set; }

        public User toUser()
        {
            return new User{
                Username=this.Username,
                Password=this.Password,
                Role=this.Role
            };
        }
    }
}