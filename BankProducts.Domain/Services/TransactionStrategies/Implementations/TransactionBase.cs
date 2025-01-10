using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Models;

namespace BankProducts.Domain.Services.TransactionStrategies.Implementations;

internal abstract class TransactionBase(IProductRepository productRepository)
{
    protected async Task<ProductAggegate> UpdateProduct(ProductAggegate product, decimal amount, TransactionModel transactionModel)
    {
        ProductAggegate productAggegate = ProductAggegate.Clone(product, amount);

        productAggegate.AddDomainEvent(new TransactionRecordedEvent(
            product.Id,
            product.ProductType,
            transactionModel.TransactionType,
            transactionModel.Amount,
            transactionModel.Description,
            product.CustomerPhone,
            product.CustomerEmail));

        await productRepository.Update(productAggegate);

        return productAggegate;
    }
}
