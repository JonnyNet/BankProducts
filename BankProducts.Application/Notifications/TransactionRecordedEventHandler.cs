namespace BankProducts.Application.Notifications;

public class TransactionRecordedEventHandler(
    ITransactionRepository transactionRepository,
    IMediator mediator) : INotificationHandler<TransactionRecordedEvent>
{
    public async Task Handle(TransactionRecordedEvent notification, CancellationToken cancellationToken)
    {
        Guid transactionId = Guid.NewGuid();
        await transactionRepository.Create(new(
            transactionId,
            notification.ProductId,
            notification.ProductType.Id,
            notification.ProductType.Description,
            notification.TransactionType.Id,
            notification.TransactionType.Description,
            notification.Amount,
            notification.Description,
            DateTime.UtcNow
        ));

        await mediator.Publish(new TransactionAlertEvent(
            notification.ProductId,
            notification.ProductType,
            notification.TransactionType,
            notification.Amount,
            notification.Description,
            notification.Phone,
            notification.Email), cancellationToken);
    }
}
