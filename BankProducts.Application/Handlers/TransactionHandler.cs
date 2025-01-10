namespace BankProducts.Application.Handlers;

public class TransactionHandler(IProductService productService) : IRequestHandler<TransactionCommand, Unit>
{
    public async Task<Unit> Handle(TransactionCommand request, CancellationToken cancellationToken)
    {
        ProductTypeEnum productType = ProductTypeEnum.Parse((short)request.Transaction.ProductTypeId)!;
        TransactionTypeEnum transactionType = TransactionTypeEnum.Parse((short)request.Transaction.TransactionType)!;

        await productService.TransactionAsyc(new(
            transactionType,
            productType,
            request.Transaction.ProductId,
            request.Transaction.Amount,
            request.Transaction.Description));

        return Unit.Value;
    }
}
