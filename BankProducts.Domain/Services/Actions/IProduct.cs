using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Models;

namespace BankProducts.Domain.Services.Actions;

internal interface IProduct
{
    short ProductTypeId { get; }
    Task<ProductAggegate> Create(ProductModel product);
}
