using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

public class ArticleModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public List<Tag> Tags { get; set; }
    public User Author { get; set; } 

    public ArticleModel(int id, string title, string content, DateTime publicationDate, List<Tag> tags, User author)
    {
        Id = id;
        Title = title;
        Content = content;
        PublicationDate = publicationDate;
        Tags = new List<Tag>();
        Author = author;
    }
}