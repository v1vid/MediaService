namespace CMS;

public class ArticleOrNews
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public List<Tag> Tags { get; set; }

    public ArticleOrNews(int id, string title, string content, DateTime publicationDate)
    {
        Id = id;
        Title = title;
        Content = content;
        PublicationDate = publicationDate;
        Tags = new List<Tag>();
    }
}


