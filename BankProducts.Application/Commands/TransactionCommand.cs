namespace BankProducts.Application.Commands;

public record TransactionCommand(TransactionDTO Transaction) : IRequest<Unit>;
public record TransactionDTO(
    TransactionType TransactionType,
    ProductType ProductTypeId,
    Guid ProductId,
    decimal Amount,
    string Description);
