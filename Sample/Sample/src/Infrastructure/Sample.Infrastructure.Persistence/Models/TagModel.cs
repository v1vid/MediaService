namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;
public class TagModel
{ 
    public int TagId { get; set; }
    public string Name { get; set; }

    public TagModel(int tagId, string name)
    {
        TagId = tagId;
        Name = name;
    }
}