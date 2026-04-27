using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private Category() { }
        public Category(string name)
        {

            Name = name;
        }
        
        public void AddCategory (string name)
        {
            Name = name;
        }
        public void Update (  string name)
        {
          
            Name = name;
        }
    }
}
