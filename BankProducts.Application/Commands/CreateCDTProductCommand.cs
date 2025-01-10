namespace BankProducts.Application.Commands;

public record CreateCDTProductCommand(CreateCDTDTO ProductDTO) : IRequest<Guid>;
public record CreateCDTDTO(string CustomerId, decimal Amount, float InterestRate);
