namespace BankProducts.Domain.Specifications;

internal class AmountGreaterThanZeroSpecification : Specification<decimal>
{
    private const string _ERROR_MESSAGE = "El valor debe ser mayor a 0.";
    public override string ErrorMessage { get; protected set; } = string.Empty;

    protected override Func<decimal, Task<bool>> Delegate => Validator;

    private Task<bool> Validator(decimal candidate)
    {
        bool validationResult = candidate > 0;

        if (!validationResult)
        {
            ErrorMessage = _ERROR_MESSAGE;
        }

        return Task.FromResult(validationResult);
    }
}
