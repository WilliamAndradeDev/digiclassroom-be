using System.ComponentModel.DataAnnotations;
using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.Web.Controllers.UserCt.Dtos
{
    public class UserForm
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
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