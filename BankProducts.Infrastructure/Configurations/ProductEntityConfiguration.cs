using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankProducts.Infrastructure.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired();

        builder.Property(x => x.CustomerId)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.Property(e => e.ProductType)
           .HasColumnType("smallint")
           .IsRequired();

        builder.Property(e => e.Amount)
           .HasColumnType("decimal(18,2)")
           .HasDefaultValue(0)
           .IsRequired();

        builder.Property(e => e.InterestRate)
           .HasColumnType("float")
           .HasDefaultValue(0.0)
           .IsRequired();

        builder.Property(e => e.Status)
           .HasColumnType("smallint")
           .IsRequired();

        builder.Property(x => x.CreatedOn)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.Property(x => x.LastModifiedOn)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.HasOne<CustomerEntity>()
               .WithMany()
               .HasForeignKey(o => o.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
