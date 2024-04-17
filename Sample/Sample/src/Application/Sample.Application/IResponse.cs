namespace Sample.Application.Sample.Application
{
    public interface IResponse
    {
        int GetStatusCode();
        dynamic GetData();
    }
}