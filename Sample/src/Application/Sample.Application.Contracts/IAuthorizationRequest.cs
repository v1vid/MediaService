namespace Sample.Application.Sample.Application.Contracts
{
    public interface IAuthorizationRequest
    { 
        string Email { get; set; }
        string Uri { get; set; }
        string ToJson();
    }
}
