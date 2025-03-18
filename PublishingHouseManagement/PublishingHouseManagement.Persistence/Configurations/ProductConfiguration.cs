using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsUnicode().IsRequired().HasMaxLength(250);
            builder.Property(x => x.Annotation).IsUnicode().IsRequired().HasMaxLength(500);
            builder.Property(x => x.ProductType);
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(13).IsFixedLength();
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.PublishingHouse);
            builder.Property(x => x.NumberOfPages);
            builder.Property(x => x.Address);
            builder.Property(x => x.IsPublished);
            builder.Property(x => x.IsArchive);
        }
    }
}