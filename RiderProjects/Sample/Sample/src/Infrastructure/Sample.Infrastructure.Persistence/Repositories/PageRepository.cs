using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class PageRepository : RepositoryBase<Page, Page>
    {
        public PageRepository(DbContext context) : base(context) { }

        protected override DbSet<Page> DbSet => _context.Set<Page>();

        protected override Page MapFrom(Page entity)
        {
            return new Page(entity.PageId, entity.Title, entity.ArticlesOrNews)
            {
                PageId = entity.PageId,
                Title = entity.Title,
                ArticlesOrNews = entity.ArticlesOrNews
            };
        }

        protected override bool Equal(Page entity, Page model)
        {
            return entity.PageId == model.PageId;
        }

        protected override void UpdateModel(Page model, Page entity)
        {
            model.Title = entity.Title;
            model.ArticlesOrNews = entity.ArticlesOrNews;
        }


        public IEnumerable<Page> GetAllPages()
        {
            return DbSet.ToList();
        }

        public Page GetPageById(int pageId)
        {
            return DbSet.FirstOrDefault(p => p.PageId == pageId);
        }

        public void AddPage(Page page)
        {
            DbSet.Add(page);
        }

        public void DeletePage(int pageId)
        {
            var pageToRemove = DbSet.FirstOrDefault(p => p.PageId == pageId);
            if (pageToRemove != null)
            {
                DbSet.Remove(pageToRemove);
            }
            else
            {
                throw new ArgumentException("Страница не найдена");
            }
        }
    }
}