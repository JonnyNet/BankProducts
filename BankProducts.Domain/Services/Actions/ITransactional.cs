using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Models;

namespace BankProducts.Domain.Services.Actions;

internal interface ITransactional : IProduct
{
    Task<ProductAggegate> Transaction(TransactionModel transactionModel);
}
