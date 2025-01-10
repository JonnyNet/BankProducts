using BankProducts.Domain.Exceptions;

namespace BankProducts.Domain.Services.TransactionStrategies.Implementations
{
    internal class TransactionContext(IEnumerable<ITransactionStrategy> transactionStrategies) : ITransactionContext
    {
        public ITransactionStrategy GetTransactionStrategy(short transactionTypeId)
        {
            ITransactionStrategy? transactionStrategy = transactionStrategies.FirstOrDefault(x => x.TransactionTypeId == transactionTypeId);

            if (transactionStrategy == default)
            {
                throw new DomainException("Tipo de transacción no soportada.");
            }

            return transactionStrategy;
        }
    }
}
