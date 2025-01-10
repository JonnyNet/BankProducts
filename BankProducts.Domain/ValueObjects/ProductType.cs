using BankProducts.Domain.Exceptions;

namespace BankProducts.Domain.ValueObjects;

internal record ProductType
{
    public ProductTypeEnum Value { get; init; }

    public ProductType(ProductTypeEnum value)
    {
        Value = value;
    }

    public ProductType(short value)
    {
        ProductTypeEnum? productTypeEnum = ProductTypeEnum.Parse(value);

        if (productTypeEnum == default)
        {
            throw new DomainException("El tipo de producto con id {0}, no es valido.", value);
        }

        Value = productTypeEnum;
    }
}
