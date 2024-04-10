namespace Sample.Application.Sample.Application.Contracts
{
    public interface IAuthorizationRequest
    { 
        string Email { get; set; }
        string Url { get; set; }
        string ToJson();
    }
}
