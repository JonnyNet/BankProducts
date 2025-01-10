using BankProducts.Domain.Repositories;

namespace BankProducts.Infrastructure.Repositories;

internal class TransactionRepository(IDbContext dbContext) : ITransactionRepository
{
    public async Task Create(TransactionEntity transaction)
    {
        await dbContext.Transactions.AddAsync(transaction);
        await dbContext.SaveChangesAsync();
    }
}
