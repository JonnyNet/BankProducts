namespace BankProducts.Infrastructure.Context;

public class BankContext(DbContextOptions<BankContext> options) : DbContext(options), IDbContext
{
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    public DbConnection GetConnection()
    {
        return Database.GetDbConnection();
    }

    public DatabaseFacade GetDatabase()
    {
        return Database;
    }
}
