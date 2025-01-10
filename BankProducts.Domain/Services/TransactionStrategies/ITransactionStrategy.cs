using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Models;

namespace BankProducts.Domain.Services.TransactionStrategies;

public interface ITransactionStrategy
{
    short TransactionTypeId { get; }
    Task<ProductAggegate> Handler(ProductAggegate product, TransactionModel transactionModel);
}
