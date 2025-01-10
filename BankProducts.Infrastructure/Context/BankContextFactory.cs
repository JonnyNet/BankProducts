namespace BankProducts.Infrastructure.Context;

internal class BankContextFactory : DbContext
{
    // dotnet ef migrations add version_2 -p BankProducts.Infrastructure -c BankContextFactory
    // dotnet ef database update --project BankProducts.Infrastructure -c BankContextFactory

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Bank");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
