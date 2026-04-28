using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class Comment
    {
        public int Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int BlogPostId { get; private set; }

        private Comment() { }

        public Comment(Guid userId, string content, int postId)
        {
          
            UserId = userId;
            Content = content;
            BlogPostId = postId;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string content)
        {
         
            Content = content;
        }
      
    }
}
