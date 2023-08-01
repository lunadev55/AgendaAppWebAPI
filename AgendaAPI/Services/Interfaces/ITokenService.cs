namespace AgendaAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtToken(string userEmail);
    }
}
