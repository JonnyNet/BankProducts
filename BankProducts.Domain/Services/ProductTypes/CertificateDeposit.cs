using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Exceptions;
using BankProducts.Domain.Models;
using BankProducts.Domain.Services.Actions;
using BankProducts.Domain.Services.TransactionStrategies;
using BankProducts.Domain.Specifications;

namespace BankProducts.Domain.Services.ProductTypes;

internal class CertificateDeposit(
    IProductRepository productRepository,
    ICustomerRepository customerRepository,
    ITransactionContext transactionContext) : Product(
        productRepository,
        customerRepository,
        transactionContext), IInterestable, ICancelable
{
    public short ProductTypeId => ProductTypeEnum.CertificateDeposit.Id;

    private readonly CompositeSpecification<float> _interestRateSpecifications = new(new InterestRateGreaterThanZeroSpecification());

    public override async Task<ProductAggegate> Create(ProductModel productModel)
    {
        await _interestRateSpecifications.ExecuteAsync(productModel.InterestRate);
        await _amuntSpecifications.ExecuteAsync(productModel.Amount);
        ProductAggegate productAggegate = await base.Create(productModel);
        return productAggegate;
    }

    public async Task<ProductAggegate> AddInterest(ProductTypeEnum productType, Guid productId, float interestRate = 0)
    {
        ProductAggegate product = await GetProduct(productType.Id, productId);
        decimal amount = product.Amount * (decimal)product.InterestRate;
        TransactionAddEvent transaction = AddTransaction(product, amount, "Abono intereses.");
        product.AddDomainEvent(transaction);

        return product;
    }

    public async Task<ProductAggegate> Cancel(ProductTypeEnum productType, Guid productId)
    {
        ProductAggegate product = await GetProduct(productType.Id, productId);

        ProductAggegate? savingAccount = await _productRepository.GetProduct(ProductTypeEnum.SavingsAccount.Id, product.CustomerId);

        if (savingAccount == default)
        {
            throw new DomainException("El cliente no tiene una cuenta de ahorros para depositar los fondos.");
        }

        ProductAggegate productAggegate = ProductAggegate.Clone(product, ProductStatusEnum.Canceled);
        TransactionAddEvent transaction = AddTransaction(savingAccount, product.Amount, "Abono capital CDT.");
        productAggegate.AddDomainEvent(transaction);

        await _productRepository.Update(productAggegate);

        return productAggegate;
    }
}
