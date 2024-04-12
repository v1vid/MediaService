using System.Text;
using Sample.Application.Sample.Application.Contracts;

namespace Sample.Application.Sample.Application;

public class AuthorizationService : IAuthorizationService
{
    private static readonly HttpClient Client = new HttpClient();
    private const string ApiBaseUrl = "https://api.example.com";

    public string SendVerificationCode(string email)
    {
        var verificationCodeRequest = new
        {
            email = email
        };

        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(verificationCodeRequest), Encoding.UTF8, "application/json");
        HttpResponseMessage response = Client.PostAsync(ApiBaseUrl + "verification-code", content).Result;

        if (response.IsSuccessStatusCode)
        {
            return "Код для авторизации успешно отправлен на почту";
        }
        else
        {
            return "Ошибка при запросе кода для авторизации";
        }
    }

    public bool AuthorizeByEmail(string email, string verificationCode)
    {
        var loginRequest = new
        {
            email = email,
            verification_code = verificationCode,
        };

        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");
        HttpResponseMessage response = Client.PostAsync(ApiBaseUrl + "login", content).Result;

        return response.IsSuccessStatusCode;
    }
}