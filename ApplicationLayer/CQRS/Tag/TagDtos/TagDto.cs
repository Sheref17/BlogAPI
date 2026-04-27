using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.TagDtos
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
