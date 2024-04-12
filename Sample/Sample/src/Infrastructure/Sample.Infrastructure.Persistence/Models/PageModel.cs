
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

public class PageModel
{
    public int PageId { get; set; }
    public string Title { get; set; }
    public List<Article> ArticlesOrNews { get; set; }

    public PageModel(int pageId, string title, List<Article> articlesOrNews)
    {
        PageId = pageId;
        Title = title;
        ArticlesOrNews = new List<Article>();
    }
    
    public void AddArticleOrNews(Article articleOrNews)
    {
        ArticlesOrNews.Add(articleOrNews);
    }
}