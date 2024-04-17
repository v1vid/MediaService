using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class PageRepository : RepositoryBase<Page, PageModel>
    {
        private readonly DbContext _context;

        public PageRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        protected override DbSet<PageModel> DbSet => _context.Set<PageModel>();

        protected override PageModel MapFrom(Page entity)
        {
            var articles = entity.ArticlesOrNews.Select(article => new ArticleModel(
                article.Id,
                article.Title,
                article.Content,
                article.PublicationDate,
                article.Tags.Select(tag => new TagModel(tag.TagId, tag.Name)).ToList(),
                article.Author
            )).ToList();

            return new PageModel(entity.PageId, entity.Title, articles)
            {
                PageId = entity.PageId,
                Title = entity.Title,
                ArticlesOrNews = articles
            };
        }

        protected override bool Equal(Page entity, PageModel model)
        {
            return entity.PageId == model.PageId;
        }

        protected override void UpdateModel(PageModel model, Page entity)
        {
            var articles = entity.ArticlesOrNews.Select(article => new ArticleModel(
                article.Id,
                article.Title,
                article.Content,
                article.PublicationDate,
                article.Tags.Select(tag => new TagModel(tag.TagId, tag.Name)).ToList(),
                article.Author
            )).ToList();

            model.Title = entity.Title;
            model.ArticlesOrNews = articles;
        }

        public IEnumerable<PageModel> GetAllPages()
        {
            return DbSet.ToList();
        }

        public Page GetPageById(int pageId)
        {
            var pageModel = DbSet.FirstOrDefault(p => p.PageId == pageId);
            if (pageModel != null)
            {
                return new Page(pageModel.PageId, pageModel.Title, pageModel.ArticlesOrNews);
            }
            else
            {
                throw new ArgumentException("Страница не найдена");
            }
        }

        public void AddPage(Page page)
        {
            DbSet.Add(MapFrom(page));
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
