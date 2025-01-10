using BankProducts.Domain.Aggregates;

namespace BankProducts.Domain.Services.Actions;

internal interface IInterestable : IProduct
{
    Task<ProductAggegate> AddInterest(ProductTypeEnum productType, Guid productId, float interestRate = default);
}
