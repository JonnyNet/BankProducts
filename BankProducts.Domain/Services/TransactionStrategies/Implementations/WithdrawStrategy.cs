using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Models;
using BankProducts.Domain.Repositories;
using BankProducts.Domain.Specifications;

namespace BankProducts.Domain.Services.TransactionStrategies.Implementations;

internal class WithdrawStrategy(IProductRepository productRepository) : TransactionBase(productRepository), ITransactionStrategy
{
    public short TransactionTypeId => TransactionTypeEnum.Withdraw.Id;

    private readonly IEnumerable<Specification<(ProductAggegate Product, decimal Amount)>> _specifications = [
        new ProductHasSufficientBalanceSpecification()
    ];

    public async Task<ProductAggegate> Handler(ProductAggegate product, TransactionModel transactionModel)
    {
        await Specification<(ProductAggegate Product, decimal Amount)>.ValidateRules(_specifications, (product, transactionModel.Amount));
        decimal amount = product.Amount - transactionModel.Amount;
        ProductAggegate productUpdate = await UpdateProduct(product, amount, transactionModel);
        return productUpdate;
    }
}
