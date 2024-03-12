using System.Collections.Generic;

namespace CMS;
public interface IAuthorizationService  
{  
    string SendVerificationCode(string email);  
    bool AuthorizeByEmail(string email, string verificationCode);  
}