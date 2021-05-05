using System;
using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.Web.Controllers.UserCt.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public UserDto(User user)
        {
            Id=user.Id;
            Username=user.Username;
            Role=user.Role;
        }
    }
}