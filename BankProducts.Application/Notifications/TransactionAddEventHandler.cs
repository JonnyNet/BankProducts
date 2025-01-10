namespace BankProducts.Application.Publishes;

internal class TransactionAddEventHandler(IProductService productService) : INotificationHandler<TransactionAddEvent>
{
    public async Task Handle(TransactionAddEvent notification, CancellationToken cancellationToken)
    {
        await productService.TransactionAsyc(new(
            notification.TransactionType,
            notification.ProductType,
            notification.ProductId,
            notification.Amount,
            notification.Description));
    }
}
