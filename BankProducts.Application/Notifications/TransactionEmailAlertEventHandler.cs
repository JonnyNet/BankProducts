using Microsoft.Extensions.Logging;

namespace BankProducts.Application.Notifications;

public class TransactionEmailAlertEventHandler(ILogger<TransactionEmailAlertEventHandler> logger) : INotificationHandler<TransactionAlertEvent>
{
    public Task Handle(TransactionAlertEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se enviara email al telefono {Phone}", notification.Email);
        return Task.CompletedTask;
    }
}
