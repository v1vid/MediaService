using System.Collections.Generic;
using CMS;

namespace CMS
{
    public interface IArticleService
    {
        IArtical GetArticle(string articleID);
        List<IArtical> GetUserArticles(string userID);
        string AddArticle(IArticleData articleData);
        IResponse AddTagsToArticle(string articleID, List<string> tags);
        IResponse DeleteTagsFromArticle(string articleID, List<string> tags);
        List<IArtical> FindArticlesByTags(List<string> tags);
    }
    
}