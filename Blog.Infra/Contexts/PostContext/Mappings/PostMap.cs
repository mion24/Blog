using Blog.Core.Contexts.PostContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Contexts.PostContext.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
               .HasColumnName("Title")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(450)
               .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(x => x.Edit)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.OwnerID)
                .HasColumnName("OwnerID")
                .HasColumnType("VARCHAR")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(x => x.RegisterDate)
                .HasColumnName("RegisterDate")
                .HasColumnType("DateTime")
                .IsRequired();
        }
    }
}
