namespace CMS.Repositories
{
    public class PageRepository
    {
        private readonly List<Page> _pages;

        public PageRepository()
        {
            _pages = new List<Page>();
        }

        public IEnumerable<Page> GetAllPages()
        {
            return _pages;
        }

        public Page GetPageById(int pageId)
        {
            return _pages.FirstOrDefault(p => p.PageId == pageId);
        }

        public void AddPage(Page page)
        {
            _pages.Add(page);
        }

        public void UpdatePage(Page pageToUpdate)
        {
            var existingPage = _pages.FirstOrDefault(p => p.PageId == pageToUpdate.PageId);
            if (existingPage != null)
            {
                existingPage.Title = pageToUpdate.Title;
                existingPage.ArticlesOrNews = pageToUpdate.ArticlesOrNews;
            }
            else
            {
                throw new ArgumentException("Страница не найдена");
            }
        }

        public void DeletePage(int pageId)
        {
            var pageToRemove = _pages.FirstOrDefault(p => p.PageId == pageId);
            if (pageToRemove != null)
            {
                _pages.Remove(pageToRemove);
            }
            else
            {
                throw new ArgumentException("Страница не найдена");
            }
        }
    }
}