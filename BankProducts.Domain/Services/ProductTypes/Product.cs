using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Exceptions;
using BankProducts.Domain.Models;
using BankProducts.Domain.Services.TransactionStrategies;
using BankProducts.Domain.Specifications;

namespace BankProducts.Domain.Services.ProductTypes;

public abstract class Product
{
    protected readonly IProductRepository _productRepository;
    protected readonly ICustomerRepository _customerRepository;
    protected readonly ITransactionContext _transactionContext;

    protected readonly CompositeSpecification<ProductAggegate> _createSpecifications;
    protected readonly CompositeSpecification<decimal> _amuntSpecifications = new(new AmountGreaterThanZeroSpecification());

    protected Product(IProductRepository productRepository, ICustomerRepository customerRepository, ITransactionContext transactionContext)
    {
        _productRepository = productRepository;
        _customerRepository = customerRepository;
        _transactionContext = transactionContext;

        _createSpecifications = new(new CustomerHasProductSpecification(_productRepository));
    }

    public virtual async Task<ProductAggegate> Create(ProductModel productModel)
    {
        CustomerEntity customer = await CustomerEntity.BuildByIdAsync(_customerRepository, productModel.CustomerId);

        Guid productId = Guid.NewGuid();
        ProductAggegate productAggegate = new(
            productId,
            customer,
            new ProductType(productModel.ProductType),
            new Amount(productModel.Amount),
            new InterestRate(productModel.InterestRate),
            DateTime.UtcNow,
            DateTime.UtcNow);

        await _createSpecifications.ExecuteAsync(productAggegate);
        await _productRepository.Create(productAggegate);

        return productAggegate;
    }

    public async Task<ProductAggegate> Transaction(TransactionModel transactionModel)
    {
        await _amuntSpecifications.ExecuteAsync(transactionModel.Amount);
        ProductAggegate product = await GetProduct(transactionModel.ProductType.Id, transactionModel.ProductId);
        ITransactionStrategy transactionStrategy = _transactionContext.GetTransactionStrategy(transactionModel.TransactionType.Id);
        ProductAggegate productUpdate = await transactionStrategy.Handler(product, transactionModel);
        return productUpdate;
    }

    protected static TransactionAddEvent AddTransaction(ProductAggegate product, decimal amount, string description)
    {
        return new(
            TransactionTypeEnum.Deposit,
            product.ProductType,
            product.Id,
            amount,
            description);
    }

    protected async Task<ProductAggegate> GetProduct(short productTypeId, Guid productId)
    {
        ProductAggegate? product = await _productRepository.GetProduct(productTypeId, productId);

        if (product == default)
        {
            throw new DomainException("El producto con id {0}, no existe.", productId);
        }

        return product;
    }
}
