using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Models;
using BankProducts.Domain.Repositories;

namespace BankProducts.Domain.Services.TransactionStrategies.Implementations;

internal class DepositStrategy(IProductRepository productRepository) : TransactionBase(productRepository), ITransactionStrategy
{
    public short TransactionTypeId => TransactionTypeEnum.Deposit.Id;

    public Task<ProductAggegate> Handler(ProductAggegate product, TransactionModel transactionModel)
    {
        decimal amount = product.Amount + transactionModel.Amount;
        return UpdateProduct(product, amount, transactionModel);
    }
}
