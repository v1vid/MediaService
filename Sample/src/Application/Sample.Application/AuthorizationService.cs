using System.Net;
using System.Net.Mail;

namespace CMS;

public class AuthorizationService: IAuthorizationService
{
    public string SendVerificationCode(string email)
    {
        string verificationCode = GenerateVerificationCode();
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress("your-email@example.com");
            mail.To.Add(email);
            mail.Subject = "Код верификации";
            mail.Body = $"Ваш код верификации: {verificationCode}";

            using (SmtpClient smtp = new SmtpClient("smtp.example.com")) // Укажите адрес SMTP-сервера
            {
                smtp.Port = 587; // Укажите порт SMTP-сервера
                smtp.Credentials = new NetworkCredential("your-email@example.com", "your-password"); // Укажите учетные данные для доступа к SMTP-серверу
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
        }

        return verificationCode;
    }

    public bool AuthorizeByEmail(string email, string verificationCode)
    {
        
    }

    private string GenerateVerificationCode()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString();
    }
}
