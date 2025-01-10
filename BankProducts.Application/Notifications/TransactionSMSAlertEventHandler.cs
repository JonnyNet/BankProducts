using Microsoft.Extensions.Logging;

namespace BankProducts.Application.Notifications;

public class TransactionSMSAlertEventHandler(ILogger<TransactionSMSAlertEventHandler> logger) : INotificationHandler<TransactionAlertEvent>
{
    public Task Handle(TransactionAlertEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Se enviara SMS al telefono {Phone}", notification.Phone);
        return Task.CompletedTask;
    }
}
