namespace BankProducts.Domain.Events;

public record TransactionRecordedEvent(
    Guid ProductId,
    ProductTypeEnum ProductType,
    TransactionTypeEnum TransactionType,
    decimal Amount,
    string Description,
    string Phone,
    string Email) : IDomainEvent;
