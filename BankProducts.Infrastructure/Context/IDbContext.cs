namespace BankProducts.Infrastructure.Context;

internal interface IDbContext
{
    DbSet<CustomerEntity> Customers { get; }
    DbSet<TransactionEntity> Transactions { get; }
    DbSet<ProductEntity> Products { get; set; }

    DbConnection GetConnection();
    DatabaseFacade GetDatabase();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
