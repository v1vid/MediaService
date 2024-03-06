namespace CMS;

public class Search
{
    public List<ArticleOrNews> SearchByTag(List<ArticleOrNews> articlesOrNews, Tag tag)
    {
        return articlesOrNews.Where(a => a.Tags.Contains(tag)).ToList();
    }

    public List<ArticleOrNews> FilterByTag(List<ArticleOrNews> articlesOrNews, Tag tag)
    {
        return articlesOrNews.Where(a => a.Tags.Contains(tag)).ToList();
    }
}