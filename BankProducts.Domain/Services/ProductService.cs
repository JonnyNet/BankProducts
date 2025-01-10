using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Exceptions;
using BankProducts.Domain.Models;
using BankProducts.Domain.Services.Actions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BankProducts.Domain.Services;

internal class ProductService(
    IServiceProvider serviceProvider,
    IMediator mediator) : IProductService
{
    public async Task<Guid> CreateAsync(ProductModel productModel)
    {
        IProduct creatable = GetProductSerice<IProduct>(productModel.ProductType.Id);
        ProductAggegate productAggegate = await creatable.Create(productModel);
        return productAggegate.Id;
    }

    public async Task TransactionAsyc(TransactionModel transactionModel)
    {
        ITransactional transactional = GetProductSerice<ITransactional>(transactionModel.ProductType.Id);
        ProductAggegate productAggegate = await transactional.Transaction(transactionModel);
        await DispatchAsync(productAggegate.GetDomainEvents());
        productAggegate.ClearDomainEvents();
    }

    public async Task CancelAsyc(ProductTypeEnum productType, Guid productId)
    {
        ICancelable cancelable = GetProductSerice<ICancelable>(productType.Id);
        ProductAggegate productAggegate = await cancelable.Cancel(productType, productId);
        await DispatchAsync(productAggegate.GetDomainEvents());
        productAggegate.ClearDomainEvents();
    }

    public async Task AddInterestAsync(ProductTypeEnum productType, Guid productId, float interestRate = 0)
    {
        IInterestable interestable = GetProductSerice<IInterestable>(productType.Id);
        ProductAggegate productAggegate = await interestable.AddInterest(productType, productId, interestRate);
        await DispatchAsync(productAggegate.GetDomainEvents());
        productAggegate.ClearDomainEvents();
    }

    private T GetProductSerice<T>(short productTypeId) where T : IProduct
    {
        IEnumerable<T> products = serviceProvider.GetServices<T>();
        T? product = products.FirstOrDefault(x => x.ProductTypeId == productTypeId);
        return product == null ? throw new DomainException("Esta operacion no es valida para este producto.") : product;
    }

    private async Task DispatchAsync(IReadOnlyList<IDomainEvent> domainEvents)
    {
        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}
