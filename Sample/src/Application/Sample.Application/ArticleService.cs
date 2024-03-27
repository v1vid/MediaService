namespace CMS;

public class ArticleService: IArticleService
{
    public Article GetArticle(int articleID)
    {
        foreach (Article article in Page.ArticlesOrNews)
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
        foreach (Article article in Page.ArticlesOrNews)
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
        Page.AddArticleOrNews(ArticlesOrNews);
        return "Article added successfully.";
    }

    public List<IArtical> FindArticlesByTags(List<Article> articlesOrNews, string tagName)
    {
        Tag tag = articlesOrNews.SelectMany(a => a.Tags).FirstOrDefault(t => t.Name == tagName);
        return Search.FilterByTag(articlesOrNews, tag);
    }
}