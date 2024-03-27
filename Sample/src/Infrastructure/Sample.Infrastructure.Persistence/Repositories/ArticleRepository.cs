namespace CMS.Repositories
{
    public class ArticleRepository
    {
        private readonly List<Article> _articles;

        public ArticleRepository()
        {
            _articles = new List<Article>();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articles;
        }

        public Article GetArticleById(int articleId)
        {
            return _articles.FirstOrDefault(a => a.Id == articleId);
        }

        public void AddArticle(Article article)
        {
            _articles.Add(article);
        }

        public void UpdateArticle(Article articleToUpdate)
        {
            var existingArticle = _articles.FirstOrDefault(a => a.Id == articleToUpdate.Id);
            if (existingArticle != null)
            {
                existingArticle.Title = articleToUpdate.Title;
                existingArticle.Content = articleToUpdate.Content;
                existingArticle.PublicationDate = articleToUpdate.PublicationDate;
                existingArticle.Tags = articleToUpdate.Tags;
                existingArticle.Author = articleToUpdate.Author;
            }
            else
            {
                throw new ArgumentException("Статья не найдена");
            }
        }

        public void DeleteArticle(int articleId)
        {
            var articleToRemove = _articles.FirstOrDefault(a => a.Id == articleId);
            if (articleToRemove != null)
            {
                _articles.Remove(articleToRemove);
            }
            else
            {
                throw new ArgumentException("Статья не найдена");
            }
        }
    }
}