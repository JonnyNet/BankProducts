using BankProducts.Domain.Aggregates;

namespace BankProducts.Domain.Specifications;

internal class ProductHasSufficientBalanceSpecification : Specification<(ProductAggegate Product, decimal Amount)>
{
    private const string _ERROR_MESSAGE = "Fondos insuficientes en la cuenta para realizar el débito.";
    public override string ErrorMessage { get; protected set; } = string.Empty;

    protected override Func<(ProductAggegate Product, decimal Amount), Task<bool>> Delegate => Validator;

    private Task<bool> Validator((ProductAggegate Product, decimal Amount) candidate)
    {
        bool validationResult = candidate.Product.Amount > candidate.Amount;

        if (!validationResult)
        {
            ErrorMessage = _ERROR_MESSAGE;
        }

        return Task.FromResult(validationResult);
    }
}
