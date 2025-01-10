namespace BankProducts.Application.Handlers;

public class CancelProductHandler(IProductService productService) : IRequestHandler<CancelProductCommad, Unit>
{
    public async Task<Unit> Handle(CancelProductCommad request, CancellationToken cancellationToken)
    {
        ProductTypeEnum productType = ProductTypeEnum.Parse((short)request.ProductDTO.ProductTypeId)!;

        await productService.CancelAsyc(productType, request.ProductDTO.ProductId);

        return Unit.Value;
    }
}
