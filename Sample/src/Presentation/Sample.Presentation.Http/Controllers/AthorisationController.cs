using Microsoft.AspNetCore.Mvc;
using Sample.Application.Sample.Application.Contracts;

namespace Sample.Presentation.Sample.Presentation.Http.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("send-verification-code")]
        public IActionResult SendVerificationCode([FromBody] string email)
        {
            string result = _authorizationService.SendVerificationCode(email);
            return Ok(result);
        }

        [HttpPost("authorize")]
        public IActionResult AuthorizeByEmail([FromBody] AuthorizationRequest request)
        {
            bool isAuthorized = _authorizationService.AuthorizeByEmail(request.Email, request.VerificationCode);
            if (isAuthorized)
                return Ok("Авторизация успешна");
            else
                return BadRequest("Ошибка авторизации");
        }
    }

    public class AuthorizationRequest
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}