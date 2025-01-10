namespace BankProducts.Domain.Models;

public record TransactionModel(TransactionTypeEnum TransactionType, ProductTypeEnum ProductType, Guid ProductId, decimal Amount, string Description);
