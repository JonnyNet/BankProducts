using BankProducts.Domain.Aggregates;

namespace BankProducts.Domain.Services.Actions;

internal interface ICancelable : IProduct
{
    Task<ProductAggegate> Cancel(ProductTypeEnum productType, Guid productId);
}
