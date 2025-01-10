namespace BankProducts.Domain.Entities;

public record TransactionEntity(
    Guid Id,
    Guid ProductId,
    short ProductTypeId,
    string ProductTypeName,
    short TransactionTypeId,
    string TransactionName,
    decimal Amount,
    string Description,
    DateTime CreatedOn);
