using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class TagRepository : RepositoryBase<Tag, TagModel>
    {
        private readonly DbContext _context;

        public TagRepository(DbContext context) : base(context) 
        {
            _context = context;

        }

        protected override DbSet<TagModel> DbSet => _context.Set<TagModel>();

        protected override TagModel MapFrom(Tag entity)
        {
            return new TagModel(entity.TagId, entity.Name)
            {
                TagId = entity.TagId,
                Name = entity.Name
            };
        }

        protected override bool Equal(Tag entity, TagModel model)
        {
            return entity.TagId == model.TagId;
        }

        protected override void UpdateModel(TagModel model, Tag entity)
        {
            model.Name = entity.Name;
        }


        public IEnumerable<TagModel> GetAllTags()
        {
            return DbSet.ToList();
        }

        public Tag GetTagById(int tagId)
        {
            var tagModel = DbSet.FirstOrDefault(t => t.TagId == tagId);
            if (tagModel != null)
            {
                return new Tag(tagModel.TagId, tagModel.Name);
            }
            else
            {
                throw new ArgumentException("Тег не найден");
            }
        }

        public Tag GetTagByName(string tagName)
        {
            var tagModel = DbSet.FirstOrDefault(t => t.Name == tagName);
            if (tagModel != null)
            {
                return new Tag(tagModel.TagId, tagModel.Name);
            }
            else
            {
                throw new ArgumentException("Тег не найден");
            }
        }

        public void AddTag(Tag tag)
        {
            DbSet.Add(MapFrom(tag));
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