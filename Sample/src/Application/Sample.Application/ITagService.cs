namespace Sample.Application.Sample.Application;
public interface ITagService
{
    List<string> GetTagsForArticle(string articleID);

    string AddTagsToArticle(int articleID, List<string> tagNames);

    string DeleteTagsFromArticle(int articleID, List<string> tagNames);
}