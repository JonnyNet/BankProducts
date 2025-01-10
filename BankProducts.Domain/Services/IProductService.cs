using BankProducts.Domain.Models;

namespace BankProducts.Domain.Services;

public interface IProductService
{
    Task<Guid> CreateAsync(ProductModel productModel);
    Task TransactionAsyc(TransactionModel transactionModel);
    Task CancelAsyc(ProductTypeEnum productType, Guid ProductId);
    Task AddInterestAsync(ProductTypeEnum productType, Guid productId, float interestRate = default);
}
