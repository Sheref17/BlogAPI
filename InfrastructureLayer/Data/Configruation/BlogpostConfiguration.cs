using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Data.Configruation
{
    public class BlogpostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasMany(p => p.Comments)
                    .WithOne()
                    .HasForeignKey(c => c.BlogPostId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Tags)
                .WithOne()
                .HasForeignKey(t => t.BlogPostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
