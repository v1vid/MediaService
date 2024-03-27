
namespace CMS;

public class Page
{
    public int PageId { get; set; }
    public string Title { get; set; }
    public List<Article> ArticlesOrNews { get; set; }

    public Page(int pageId, string title)
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