using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Application.Sample.Application;
public class TagService : ITagService
{
    private readonly Page _page;
    private readonly Article _article;
    
    public TagService(Page page, Article article)
    {
        _page = page;
        _article = article;
    }

    public List<string> GetTagsForArticle(string articleID)
    {
        List<string> TagsforArticle = new List<string>();

        foreach (Article article in _page.ArticlesOrNews)
        {
            if (articleID == article.Id.ToString())
            {
                foreach (Tag tag in article.Tags)
                {
                    TagsforArticle.Add(tag.Name);
                }
            }
        }

        return TagsforArticle;
    }

    public string AddTagsToArticle(int articleID, List<string> tagNames)
    {
        int tagId = _article.Tags.Count;
        foreach (Article article in _page.ArticlesOrNews)
        {
            if (articleID == article.Id)
            {
                List<Tag> tagsToAdd = new List<Tag>();
                foreach (string tagName in tagNames)
                {
                    Tag tag = new Tag(tagId, tagName);
                    tagsToAdd.Add(tag);
                }

                article.Tags.AddRange(tagsToAdd);
                return "Теги успешно добавлены";
            }
        }

        return "Статья с указанным ID не найдена";
    }

    public string DeleteTagsFromArticle(int articleID, List<string> tagNames)
    {
        foreach (Article article in _page.ArticlesOrNews)
        {
            if (articleID == article.Id)
            {
                List<Tag> tagsToDelete = new List<Tag>();
                foreach (string tagName in tagNames)
                {
                    Tag tagToRemove = article.Tags.FirstOrDefault(t => t.Name == tagName);
                    if (tagToRemove != null)
                    {
                        tagsToDelete.Add(tagToRemove);
                    }
                }

                foreach (Tag tag in tagsToDelete)
                {
                    article.Tags.Remove(tag);
                }

                return "Теги успешно удалены";
            }
        }

        return "Статья с указанным ID не найдена";
    }
}