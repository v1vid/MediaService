namespace Sample.Application.Sample.Application
{
    public interface IArticleData
    {
        string Title { get; set; }
        string Content { get; set; }
        List<string> Tags { get; set; }
    }
}