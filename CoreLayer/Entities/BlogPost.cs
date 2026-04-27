using CoreLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreLayer.Entities
{
    public class BlogPost
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid AuthorId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PostStatus Status { get; private set; }
        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments;
        private readonly List<Tag> _tags = new();
        public IReadOnlyCollection<Tag> Tags => _tags;
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        private BlogPost() { }
        public BlogPost(string title, string content, Guid authorId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required");


            Title = title;
            Content = content;
            AuthorId = authorId;
            CategoryId = categoryId;
            CreatedAt = DateTime.UtcNow;
            Status = PostStatus.Draft;
        }
        public void Publish()
        {
            if (Status != PostStatus.Draft)
                throw new Exception("Only draft can be published");

            Status = PostStatus.Published;
        }
        public void Update(string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Invalid title");

            Title = title;
            Content = content;
        }
        
       

        public void ChangeCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public void AddTag(Tag tag)
        {
            _tags.Add(tag);
        }

        public void RemoveTag(Tag tag)
        {
            _tags.Remove(tag);
        }
        public void RemoveComment(int commentId)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == commentId);
            if (comment is null) throw new Exception("Comment not found");
            _comments.Remove(comment);

        }
        public void UpdateComment(int commentId, string content)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
                throw new Exception("Comment not found");

            comment.Update(content);
        }

    }
}
