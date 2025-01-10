using BankProducts.Domain.Aggregates;

namespace BankProducts.Domain.Entities;

public record CustomerProductEntity(
    Guid Id,
    string CustomerId,
    string CustomerName,
    string CustomerPhone,
    string CustomerEmail,
    short ProductType,
    decimal Amount,
    double InterestRate,
    short Status,
    DateTime CreatedOn,
    DateTime LastModifiedOn)
{
    public static implicit operator ProductAggegate?(CustomerProductEntity? entity)
    {
        ProductAggegate? productAggegate = default;

        if (entity != default)
        {
            productAggegate = new(
                entity.Id,
                entity.CustomerId,
                entity.CustomerName,
                entity.CustomerPhone,
                entity.CustomerEmail,
                entity.ProductType,
                entity.Amount,
                (float)entity.InterestRate,
                (ProductStatusEnum)entity.Status,
                entity.CreatedOn,
                entity.LastModifiedOn);
        }

        return productAggegate;
    }
}
