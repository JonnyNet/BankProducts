namespace BankProducts.Application.Handlers;

public class CreateAccountProductHandler(IProductService productService) : IRequestHandler<CreateAccountProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateAccountProductCommand request, CancellationToken cancellationToken)
    {
        ProductTypeEnum productType = ProductTypeEnum.Parse((short)request.ProductDTO.ProductTypeId)!;

        Guid guid = await productService.CreateAsync(new(
            request.ProductDTO.CustomerId,
            productType,
            default,
            default));

        return guid;
    }
}
