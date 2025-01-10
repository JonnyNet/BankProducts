using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Services.Actions;
using BankProducts.Domain.Services.TransactionStrategies;

namespace BankProducts.Domain.Services.ProductTypes;

internal class CheckingAccount(
    IProductRepository productRepository,
    ICustomerRepository customerRepository,
    ITransactionContext transactionContext) :
    Product(
        productRepository,
        customerRepository,
        transactionContext), ITransactional, ICancelable
{
    public short ProductTypeId => ProductTypeEnum.CheckingAccount.Id;

    public Task<ProductAggegate> Cancel(ProductTypeEnum productType, Guid productId)
    {
        throw new NotImplementedException();
    }
}
