namespace CMS
{
    public interface IAuthorizationService
    {
        string Login(string email, string verificationCode);
    }
}