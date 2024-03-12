using System.Collections.Generic;

namespace CMS
{
    public interface IFindArticlesResponse
    {
        List<IArtical> Articles { get; set; }
    }
}