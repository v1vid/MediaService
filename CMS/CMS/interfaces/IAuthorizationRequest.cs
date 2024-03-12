using System;
namespace CMS
{
    public interface IAuthorizationRequest
    { 
        string Email { get; set; }
        string Uri { get; set; }
        string ToJson();
    }
}
