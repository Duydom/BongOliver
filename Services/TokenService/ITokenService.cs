namespace BongOliver.API.Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}
// , string firstname, string lastname, int role_id
