
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

public class PageModel
{
    public int PageId { get; set; }
    public string Title { get; set; }
    public List<ArticleModel> ArticlesOrNews { get; set; }
    
    public PageModel() { }


    public PageModel(int pageId, string title, List<ArticleModel> articlesOrNews)
    {
        PageId = pageId;
        Title = title;
        ArticlesOrNews = new List<ArticleModel>();
    }
    
    public void AddArticleOrNews(ArticleModel articleOrNews)
    {
        ArticlesOrNews.Add(articleOrNews);
    }
}