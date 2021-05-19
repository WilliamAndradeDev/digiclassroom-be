using BC = BCrypt.Net.BCrypt;

namespace DigiClassroom.ApplicationCore.Services.UtilSv.PasswordManager
{
    public class PasswordMngBCrypt : IPasswordManager
    {
        public string GeneratePasswordHash(string password)
        => BC.HashPassword(password);

        public bool IsAMatch(string candidatePassword, string sourcePassword)
        => BC.Verify(candidatePassword, sourcePassword);
    }
}
