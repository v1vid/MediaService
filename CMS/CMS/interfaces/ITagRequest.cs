using System.Collections.Generic;

namespace CMS
{
    public interface ITagRequest
    {
        List<string> Tags { get; set; }
    }
}