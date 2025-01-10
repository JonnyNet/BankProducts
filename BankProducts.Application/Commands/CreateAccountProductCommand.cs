namespace BankProducts.Application.Commands;

public record CreateAccountProductCommand(CreateAccountDTO ProductDTO) : IRequest<Guid>;
public record CreateAccountDTO(ProductType ProductTypeId, string CustomerId);
