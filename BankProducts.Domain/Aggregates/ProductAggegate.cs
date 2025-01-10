namespace BankProducts.Domain.Aggregates;

public sealed class ProductAggegate : Aggregate<Guid>
{
    private readonly CustomerEntity _customer;
    private readonly ProductType _productType;
    private readonly Amount _amount;
    private readonly InterestRate _interestRate;
    private readonly ProductStatusEnum _productStatus = ProductStatusEnum.Active;

    public string CustomerId => _customer.Id;
    public string CustomerName => _customer.Name;
    public string CustomerPhone => _customer.Phone;
    public string CustomerEmail => _customer.Email;
    public ProductTypeEnum ProductType => _productType.Value;
    public decimal Amount => _amount.Value;
    public float InterestRate => _interestRate.Value;
    public ProductStatusEnum Status => _productStatus;


    internal ProductAggegate(
        Guid id,
        CustomerEntity customer,
        ProductType typeProduct,
        Amount amount,
        InterestRate interestRate,
        DateTime createdOn,
        DateTime lastModifiedOn) : base(id, createdOn, lastModifiedOn)
    {
        _customer = customer;
        _productType = typeProduct;
        _amount = amount;
        _interestRate = interestRate;
    }

    internal ProductAggegate(
        Guid id,
        string customerId,
        string customerName,
        string customerPhone,
        string customerEmail,
        short productType,
        decimal amount,
        float interestRate,
        ProductStatusEnum status,
        DateTime createdOn,
        DateTime lastModifiedOn) : base(id, createdOn, lastModifiedOn)
    {
        _customer = new CustomerEntity(customerId, customerName, customerPhone, customerEmail);
        _productType = new ProductType(productType);
        _amount = new Amount(amount);
        _interestRate = new InterestRate(interestRate);
        _productStatus = status;
    }

    public static ProductAggegate Clone(ProductAggegate product, ProductStatusEnum status)
    {
        ProductAggegate productAggegate = new(
            product.Id,
            product.CustomerId,
            product.CustomerName,
            product.CustomerPhone,
            product.CustomerEmail,
            product.ProductType.Id,
            default,
            product.InterestRate,
            status,
            product.CreatedOn,
            DateTime.UtcNow);

        return productAggegate;
    }

    public static ProductAggegate Clone(ProductAggegate product, decimal amount)
    {
        ProductAggegate productAggegate = new(
            product.Id,
            new CustomerEntity(product.CustomerId, product.CustomerName, product.CustomerPhone, product.CustomerEmail),
            new ProductType(product.ProductType),
            new Amount(amount),
            new InterestRate(product.InterestRate),
            product.CreatedOn,
            DateTime.UtcNow);

        return productAggegate;
    }
}
