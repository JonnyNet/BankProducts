namespace BankProducts.Domain.Repositories;

public interface ITransactionRepository
{
    Task Create(TransactionEntity transaction);
}
