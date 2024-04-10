using Microsoft.AspNetCore.Mvc;
using Sample.Application.Sample.Application;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Presentation.Sample.Presentation.Http.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{articleID}")]
        public IActionResult GetArticle(int articleID)
        {
            Article article = _articleService.GetArticle(articleID);
            if (article == null)
                return NotFound();

            return Ok(article);
        }

        [HttpGet("user/{userID}")]
        public IActionResult GetUserArticles(int userID)
        {
            List<Article> userArticles = _articleService.GetUserArticles(userID);
            return Ok(userArticles);
        }

        [HttpPost]
        public IActionResult AddArticle([FromBody] Article article)
        {
            string result = _articleService.AddArticle(article);
            return Ok(result);
        }

        [HttpGet("tags/{tagName}")]
        public IActionResult FindArticlesByTags(string tagName)
        {
            List<Article> filteredArticles = _articleService.FindArticlesByTags(tagName);
            return Ok(filteredArticles);
        }
    }
}