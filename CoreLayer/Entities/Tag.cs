using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class Tag
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        private Tag() { 
        }
        public Tag(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

        }
    }
}
