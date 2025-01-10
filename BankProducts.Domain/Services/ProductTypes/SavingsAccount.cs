using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Services.Actions;
using BankProducts.Domain.Services.TransactionStrategies;

namespace BankProducts.Domain.Services.ProductTypes;

internal class SavingsAccount(
    IProductRepository productRepository,
    ICustomerRepository customerRepository,
    ITransactionContext transactionContext) :
    Product(
        productRepository,
        customerRepository,
        transactionContext), ITransactional, IInterestable
{
    public short ProductTypeId => ProductTypeEnum.SavingsAccount.Id;

    public async Task<ProductAggegate> AddInterest(ProductTypeEnum productType, Guid productId, float interestRate)
    {
        ProductAggegate product = await GetProduct(productType.Id, productId);
        decimal amount = product.Amount * (decimal)interestRate;
        TransactionAddEvent transaction = AddTransaction(product, amount, "Abono intereses.");
        product.AddDomainEvent(transaction);
        return product;
    }


}
