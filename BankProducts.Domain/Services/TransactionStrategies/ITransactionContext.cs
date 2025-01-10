namespace BankProducts.Domain.Services.TransactionStrategies;

public interface ITransactionContext
{
    ITransactionStrategy GetTransactionStrategy(short transactionTypeId);
}
