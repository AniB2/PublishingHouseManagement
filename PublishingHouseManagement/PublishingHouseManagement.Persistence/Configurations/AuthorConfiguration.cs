using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsUnicode().IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsUnicode().IsRequired().HasMaxLength(50);
            builder.Property(x => x.Gender);
            builder.HasIndex(x => x.PrivateNumber).IsUnique();
            builder.Property(x => x.PrivateNumber).IsRequired().HasMaxLength(11).IsFixedLength();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.City);
            builder.Property(x => x.Country);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.Email);
            builder.Property(x => x.Email);
            builder.Property(x => x.IsDelete);
            builder.HasQueryFilter(x => !x.IsDelete);

            builder.HasMany(x => x.Products)
             .WithMany(x => x.Authors)
             .UsingEntity<Dictionary<int, int>>(
                 "ProductAuthor",
                 j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                 j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId")
             );
        }
    }
}