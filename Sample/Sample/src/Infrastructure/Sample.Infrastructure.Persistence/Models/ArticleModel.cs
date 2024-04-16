using Sample.Application.Sample.Application;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;



public class ArticleModel 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public List<TagModel> Tags { get; set; }
    public UserModel Author { get; set; } 

    public ArticleModel() { }

    public ArticleModel(int id, string title, string content, DateTime publicationDate, List<TagModel> tags, UserModel author)
    {
        Id = id;
        Title = title;
        Content = content;
        PublicationDate = publicationDate;
        Tags = new List<TagModel>();
        
        Author = author;
    }


}