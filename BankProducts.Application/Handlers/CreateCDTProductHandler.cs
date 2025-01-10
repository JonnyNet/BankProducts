namespace BankProducts.Application.Handlers;

public class CreateCDTProductHandler(IProductService productService) : IRequestHandler<CreateCDTProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateCDTProductCommand request, CancellationToken cancellationToken)
    {
        ProductTypeEnum productType = ProductTypeEnum.CertificateDeposit;

        Guid productId = await productService.CreateAsync(new(
            request.ProductDTO.CustomerId,
            productType,
            request.ProductDTO.Amount,
            request.ProductDTO.InterestRate));

        return productId;
    }
}
