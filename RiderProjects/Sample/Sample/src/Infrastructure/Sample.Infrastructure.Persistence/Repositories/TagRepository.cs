using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class TagRepository : RepositoryBase<Tag, Tag>
    {
        public TagRepository(DbContext context) : base(context) { }

        protected override DbSet<Tag> DbSet => _context.Set<Tag>();

        protected override Tag MapFrom(Tag entity)
        {
            return new Tag
            {
                TagId = entity.TagId,
                Name = entity.Name
            };
        }

        protected override bool Equal(Tag entity, Tag model)
        {
            return entity.TagId == model.TagId;
        }

        protected override void UpdateModel(Tag model, Tag entity)
        {
            model.Name = entity.Name;
        }


        public IEnumerable<Tag> GetAllTags()
        {
            return DbSet.ToList();
        }

        public Tag GetTagById(int tagId)
        {
            return DbSet.FirstOrDefault(t => t.TagId == tagId);
        }

        public Tag GetTagByName(string tagName)
        {
            return DbSet.FirstOrDefault(t => t.Name == tagName);
        }

        public void AddTag(Tag tag)
        {
            DbSet.Add(tag);
        }

        public void DeleteTag(int tagId)
        {
            var tagToRemove = DbSet.FirstOrDefault(t => t.TagId == tagId);
            if (tagToRemove != null)
            {
                DbSet.Remove(tagToRemove);
            }
            else
            {
                throw new ArgumentException("Тег не найден");
            }
        }
    }
}