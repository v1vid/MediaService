using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

namespace Sample.Application.Sample.Application.Models.DTO;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public List<Tag> Tags { get; set; }
    public UserModel Author { get; set; } 

    public Article(int id, string title, string content, DateTime publicationDate, List<TagModel> tags, UserModel author)
    {
        Id = id;
        Title = title;
        Content = content;
        PublicationDate = publicationDate;
        Tags = new List<Tag>();
        Author = author;
    }
}