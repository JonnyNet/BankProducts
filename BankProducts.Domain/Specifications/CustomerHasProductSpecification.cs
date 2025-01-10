using BankProducts.Domain.Aggregates;

namespace BankProducts.Domain.Specifications;

internal class CustomerHasProductSpecification(IProductRepository productRepository) : Specification<ProductAggegate>
{
    private const string _ERROR_MESSAGE = "El cliente con id {0} ya tiene una cuenta de typo {1}.";
    public override string ErrorMessage { get; protected set; } = string.Empty;

    protected override Func<ProductAggegate, Task<bool>> Delegate => Validator;


    private async Task<bool> Validator(ProductAggegate product)
    {
        CustomerProductEntity? entity = await productRepository.GetProduct(product.ProductType.Id, product.CustomerId);
        bool validationResult = entity == default;
        if (!validationResult)
        {
            ErrorMessage = string.Format(_ERROR_MESSAGE, product.CustomerId, product.ProductType);
        }
        return validationResult;
    }
}
