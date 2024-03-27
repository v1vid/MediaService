namespace CMS
{
    public interface IResponse
    {
        int GetStatusCode();
        dynamic GetData();
    }
}