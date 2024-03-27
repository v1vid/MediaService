namespace CMS;

public class Search
{
    public List<Article> SearchByTag(List<Article> articlesOrNews, Tag tag)
    {
        return articlesOrNews.Where(a => a.Tags.Contains(tag)).ToList();
    }

    public List<Article> FilterByTag(List<Article> articlesOrNews, Tag tag)
    {
        return articlesOrNews.Where(a => a.Tags.Contains(tag)).ToList();
    }
    
    public List<Article> SearchByTitle(List<Article> articlesOrNews, string title)
    {
        return articlesOrNews.Where(a => a.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}