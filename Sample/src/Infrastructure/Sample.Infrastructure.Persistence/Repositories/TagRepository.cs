namespace CMS.Repositories
{
    public class TagRepository
    {
        private readonly List<Tag> _tags;

        public TagRepository()
        {
            _tags = new List<Tag>();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _tags;
        }

        public Tag GetTagById(int tagId)
        {
            return _tags.FirstOrDefault(t => t.TagId == tagId);
        }

        public Tag GetTagByName(string tagName)
        {
            return _tags.FirstOrDefault(t => t.Name == tagName);
        }

        public void AddTag(Tag tag)
        {
            _tags.Add(tag);
        }

        public void UpdateTag(Tag tagToUpdate)
        {
            var existingTag = _tags.FirstOrDefault(t => t.TagId == tagToUpdate.TagId);
            if (existingTag != null)
            {
                existingTag.Name = tagToUpdate.Name;
            }
            else
            {
                throw new ArgumentException("Тег не найден");
            }
        }

        public void DeleteTag(int tagId)
        {
            var tagToRemove = _tags.FirstOrDefault(t => t.TagId == tagId);
            if (tagToRemove != null)
            {
                _tags.Remove(tagToRemove);
            }
            else
            {
                throw new ArgumentException("Тег не найден");
            }
        }
    }
}