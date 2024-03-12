using System.Collections.Generic;

namespace CMS
{
    public interface IFindArticlesRequest
    {
        List<string> Tags { get; set; }
    }
}