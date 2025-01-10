namespace BankProducts.Domain.Entities;

public record ProductEntity(
    Guid Id,
    string CustomerId,
    short ProductType,
    decimal Amount,
    float InterestRate,
    short Status,
    DateTime CreatedOn,
    DateTime LastModifiedOn);
