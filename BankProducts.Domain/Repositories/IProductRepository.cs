using BankProducts.Domain.Aggregates;

namespace BankProducts.Domain.Repositories;

public interface IProductRepository
{
    Task Create(ProductAggegate product);
    Task Update(ProductAggegate product);
    Task<CustomerProductEntity?> GetProduct(short productTypeId, Guid ProductId);
    Task<CustomerProductEntity?> GetProduct(short productTypeId, string customerId);
}
