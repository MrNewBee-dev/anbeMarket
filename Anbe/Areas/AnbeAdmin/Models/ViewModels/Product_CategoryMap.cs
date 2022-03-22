
using Anbe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anbe.Mapping
{
    public class Product_CategoryMap : IEntityTypeConfiguration<Product_Category>
    {
        public void Configure(EntityTypeBuilder<Product_Category> builder)
        {
            builder.HasKey(t => new { t.ProductID, t.CategoryID });
            builder
                .HasOne(p => p.Product)
                .WithMany(c => c.book_Categories)
                .HasForeignKey(f => f.ProductID);

            builder
               .HasOne(p => p.Category)
               .WithMany(c => c.Product_Categories)
               .HasForeignKey(f => f.CategoryID);
        }
    }
}
