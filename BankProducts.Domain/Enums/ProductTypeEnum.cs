namespace BankProducts.Domain.Enums;

public class ProductTypeEnum : Enumeration
{
    public static readonly ProductTypeEnum SavingsAccount = new(1, nameof(SavingsAccount), "Cuenta de ahorros");
    public static readonly ProductTypeEnum CheckingAccount = new(2, nameof(CheckingAccount), "Cuenta corriente");
    public static readonly ProductTypeEnum CertificateDeposit = new(3, nameof(CertificateDeposit), "CDT");

    protected ProductTypeEnum(short id, string name, string description) : base(id, name, description)
    {
    }

    public static ProductTypeEnum? Parse(short id)
    {
        ProductTypeEnum? item = BuildItem<ProductTypeEnum>(id);
        return item;
    }
}
