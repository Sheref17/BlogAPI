using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.CommentDtos
{
    public class CommentDto
    {
        public string Content { get; set; } = default!;
        public string UserName { get; set; } = default!;
    }
}
