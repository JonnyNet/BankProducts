namespace BankProducts.Domain.Events;

public record TransactionAlertEvent(
    Guid ProductId,
    ProductTypeEnum ProductTypeEnum,
    TransactionTypeEnum TransactionTypeEnum,
    decimal Amount,
    string Description,
    string Phone,
    string Email) : IDomainEvent;

