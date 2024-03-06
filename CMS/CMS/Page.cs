namespace CMS;

public class Page
{
    public int PageId { get; set; }
    public string Title { get; set; }
    public List<ArticleOrNews> ArticlesOrNews { get; set; }

    public Page(int pageId, string title)
    {
        PageId = pageId;
        Title = title;
        ArticlesOrNews = new List<ArticleOrNews>();
    }
    
    public void AddArticleOrNews(ArticleOrNews articleOrNews)
    {
        ArticlesOrNews.Add(articleOrNews);
    }
}
