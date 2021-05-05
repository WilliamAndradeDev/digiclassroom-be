namespace DigiClassroom.Web.Controllers.AuthenticationCt.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string Type { get; set; }

        public TokenDto(string token,string type="Bearer")
        {
            Token=token;
            Type=type;
        }

    }
}