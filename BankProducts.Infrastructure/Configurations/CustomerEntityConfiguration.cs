using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankProducts.Infrastructure.Configurations;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(e => e.Id)
            .IsUnique();

        builder.Property(x => x.Id)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.HasData(
            new CustomerEntity("1047389512", "Jonny Rojas", "573002672776", "jonny_rojas@satrack.com"),
            new CustomerEntity("1128061907", "Juan Perez", "573002672776", "jonny_rojas@satrack.com")
        );
    }
}
