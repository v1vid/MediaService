namespace Sample.Application.Sample.Application.Contracts;
public interface IAuthorizationService  
{  
    string SendVerificationCode(string email);  
    bool AuthorizeByEmail(string email, string verificationCode);  
}