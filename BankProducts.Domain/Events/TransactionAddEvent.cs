namespace BankProducts.Domain.Events;

public record TransactionAddEvent(TransactionTypeEnum TransactionType, ProductTypeEnum ProductType, Guid ProductId, decimal Amount, string Description) : IDomainEvent;
