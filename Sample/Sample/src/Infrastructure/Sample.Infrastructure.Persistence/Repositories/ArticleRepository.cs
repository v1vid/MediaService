using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class ArticleRepository : RepositoryBase<Article, ArticleModel>
    {
        private readonly DbContext _context;

        public ArticleRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        protected override DbSet<ArticleModel> DbSet => _context.Set<ArticleModel>();

        protected override ArticleModel MapFrom(Article entity)
        {
            // Конвертируем список Tag в список TagModel
            var tags = entity.Tags.Select(tag => new TagModel(tag.TagId, tag.Name)).ToList();

            return new ArticleModel(entity.Id,
                entity.Title,
                entity.Content,
                entity.PublicationDate,
                tags,  // передаем сконвертированный список
                entity.Author);
        }

        protected override bool Equal(Article entity, ArticleModel model)
        {
            return entity.Id == model.Id;
        }

        protected override void UpdateModel(ArticleModel model, Article entity)
        {
            model.Title = entity.Title;
            model.Content = entity.Content;
            model.PublicationDate = entity.PublicationDate;

            var tags = entity.Tags.Select(tag => new TagModel(tag.TagId, tag.Name)).ToList();
            model.Tags = tags; 
            model.Author = entity.Author;
        }


        public IEnumerable<ArticleModel> GetAllArticles()
        {
            return DbSet.ToList();
        }

        public Article GetArticleById(int articleId)
        {
            var articleModel = DbSet.FirstOrDefault(a => a.Id == articleId);
            if (articleModel != null)
            {
                return new Article(articleModel.Id,
                    articleModel.Title,
                    articleModel.Content,
                    articleModel.PublicationDate,
                    articleModel.Tags,
                    articleModel.Author);
            }
            else
            {
                throw new ArgumentException("Статья не найдена");
            }
        }

        public void AddArticle(Article article)
        {
            DbSet.Add(MapFrom(article));
        }

        public void DeleteArticle(int articleId)
        {
            var articleToRemove = DbSet.FirstOrDefault(a => a.Id == articleId);
            if (articleToRemove != null)
            {
                DbSet.Remove(articleToRemove);
            }
            else
            {
                throw new ArgumentException("Статья не найдена");
            }
        }
    }
}
