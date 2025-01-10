namespace BankProducts.Domain.Enums;

public class TransactionTypeEnum : Enumeration
{
    public static readonly TransactionTypeEnum Deposit = new(1, nameof(Deposit), "Deposito");
    public static readonly TransactionTypeEnum Withdraw = new(2, nameof(Withdraw), "Retiro");

    protected TransactionTypeEnum(short id, string name, string description) : base(id, name, description)
    {
    }

    public static TransactionTypeEnum? Parse(short id)
    {
        TransactionTypeEnum? item = BuildItem<TransactionTypeEnum>(id);
        return item;
    }
}
