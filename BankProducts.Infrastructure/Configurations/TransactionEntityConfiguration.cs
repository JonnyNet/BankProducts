using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankProducts.Infrastructure.Configurations;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired();

        builder.Property(e => e.ProductTypeId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired();

        builder.Property(e => e.ProductTypeId)
           .HasColumnType("smallint")
           .IsRequired();

        builder.Property(x => x.ProductTypeName)
            .HasColumnType("nvarchar(30)")
            .IsRequired();

        builder.Property(e => e.TransactionTypeId)
           .HasColumnType("smallint")
           .IsRequired();

        builder.Property(x => x.TransactionName)
            .HasColumnType("nvarchar(30)")
            .IsRequired();

        builder.Property(e => e.Amount)
           .HasColumnType("decimal(18,2)")
           .HasPrecision(18, 2)
           .HasDefaultValue(0)
           .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(x => x.CreatedOn)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.HasOne<ProductEntity>()
               .WithMany()
               .HasForeignKey(o => o.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
