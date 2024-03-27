using System.Collections.Generic;
using CMS;

namespace CMS;
public interface ITagService  
{  
    List<string> GetTagsForArticle(string articleID);  
    IResponse AddTagsToArticle(string articleID, List<string> tags);  
    IResponse DeleteTagsFromArticle(string articleID, List<string> tags);  
}