using Microsoft.AspNetCore.Mvc;
using Sample.Application.Sample.Application;

namespace Sample.Presentation.Sample.Presentation.Http.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("{articleID}")]
        public IActionResult GetTagsForArticle(string articleID)
        {
            List<string> tags = _tagService.GetTagsForArticle(articleID);
            return Ok(tags);
        }

        [HttpPost("{articleID}")]
        public IActionResult AddTagsToArticle(string articleID, [FromBody] List<string> tagNames)
        {
            string result = _tagService.AddTagsToArticle(Convert.ToInt32(articleID), tagNames);
            return Ok(result);
        }

        [HttpPost("{articleID}/delete")]
        public IActionResult DeleteTagsFromArticle(string articleID, [FromBody] List<string> tagNames)
        {
            string result = _tagService.DeleteTagsFromArticle(Convert.ToInt32(articleID), tagNames);
            return Ok(result);
        }
    }
}