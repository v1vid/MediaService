namespace CMS;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public List<Tag> Tags { get; set; }
    public User Author { get; set; } 

    public Article(int id, string title, string content, DateTime publicationDate, User author)
    {
        Id = id;
        Title = title;
        Content = content;
        PublicationDate = publicationDate;
        Tags = new List<Tag>();
        Author = author;
    }
}