using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Application.Sample.Application;

public class ArticleService : IArticleService
{
    private readonly Search _search;
    
    private readonly Page _page;

    public ArticleService(Page page, Search search)
    {
        _page = page;
        _search = search;
    }
    public Article GetArticle(int articleID)
    {
        foreach (Article article in _page.ArticlesOrNews)
        {
            if (articleID == article.Id)
            {
                return article;
            }
        }

        return null;
    }

    public List<Article> GetUserArticles(int userID)
    {
        List<Article> Articles = new List<Article>();
        foreach (Article article in _page.ArticlesOrNews)
        {
            if (article.Author.UserId == userID)
            {
                Articles.Add(article);
            }
        }

        return Articles;
    }

    public string AddArticle(Article ArticlesOrNews)
    {
        
        _page.AddArticleOrNews(ArticlesOrNews);
        return "Article added successfully.";
    }

    public List<Article> FindArticlesByTags(string tagName){
        List<Article> articlesOrNews = _page.ArticlesOrNews;    Tag tag = articlesOrNews.SelectMany(a => a.Tags).FirstOrDefault(t => t.Name == tagName);
        return _search.FilterByTag(articlesOrNews, tag);}
    
}