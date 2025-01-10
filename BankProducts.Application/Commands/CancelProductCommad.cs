namespace BankProducts.Application.Commands;

public record CancelProductCommad(CancelProductDTO ProductDTO) : IRequest<Unit>;
public record CancelProductDTO(ProductType ProductTypeId, Guid ProductId);

