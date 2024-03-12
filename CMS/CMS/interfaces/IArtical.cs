using System.Collections.Generic;

namespace CMS
{
    public interface IArtical
    {
        string Id { get; set; }
        string Title { get; set; }
        string Content { get; set; }
        string PublicationDate { get; set; }
        List<string> Tags { get; set; }
    }

}