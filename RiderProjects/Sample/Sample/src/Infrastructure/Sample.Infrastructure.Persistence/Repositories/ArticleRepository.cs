using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class ArticleRepository : RepositoryBase<Article, Article>
    {
        public ArticleRepository(DbContext context) : base(context) { }

        protected override DbSet<Article> DbSet => _context.Set<Article>();

        protected override Article MapFrom(Article entity)
        {
            return new Article(entity.Id, entity.Title, entity.Content, entity.PublicationDate, entity.Tags, entity.Author);
        }

        protected override bool Equal(Article entity, Article model)
        {
            return entity.Id == model.Id;
        }

        protected override void UpdateModel(Article model, Article entity)
        {
            model.Title = entity.Title;
            model.Content = entity.Content;
            model.PublicationDate = entity.PublicationDate;
            model.Tags = entity.Tags;
            model.Author = entity.Author;
        }


        public IEnumerable<Article> GetAllArticles()
        {
            return DbSet.ToList();
        }

        public Article GetArticleById(int articleId)
        {
            return DbSet.FirstOrDefault(a => a.Id == articleId);
        }

        public void AddArticle(Article article)
        {
            DbSet.Add(article);
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