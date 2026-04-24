using CoreLayer.Entities;
using InfrastructureLayer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser ,IdentityRole<Guid> ,Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
