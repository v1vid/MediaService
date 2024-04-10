using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Application.Sample.Application{
    public interface IArticleService
    {
        Article GetArticle(int articleID);

        List<Article> GetUserArticles(int userID);

        string AddArticle(Article ArticlesOrNews);

        List<Article> FindArticlesByTags( string tagName);
    }

}