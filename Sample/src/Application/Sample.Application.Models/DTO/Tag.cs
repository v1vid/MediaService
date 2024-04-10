namespace Sample.Application.Sample.Application.Models.DTO;
public class Tag
{ 
    public int TagId { get; set; }
    public string Name { get; set; }

    public Tag(int tagId, string name)
    {
        TagId = tagId;
        Name = name;
    }
}