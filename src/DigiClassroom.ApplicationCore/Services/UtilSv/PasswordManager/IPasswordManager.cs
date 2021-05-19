namespace DigiClassroom.ApplicationCore.Services.UtilSv.PasswordManager
{
    public interface IPasswordManager
    {
        string GeneratePasswordHash(string password);
        bool IsAMatch(string candidatePassword, string sourcePassword);
    }
}
