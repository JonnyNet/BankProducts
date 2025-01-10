namespace BankProducts.Domain.Specifications;

internal class InterestRateGreaterThanZeroSpecification : Specification<float>
{
    private const string _ERROR_MESSAGE = "El valor de los interese debe ser mayor a 0.";
    public override string ErrorMessage { get; protected set; } = string.Empty;

    protected override Func<float, Task<bool>> Delegate => Validator;

    private Task<bool> Validator(float candidate)
    {
        bool validationResult = candidate > 0;

        if (!validationResult)
        {
            ErrorMessage = _ERROR_MESSAGE;
        }

        return Task.FromResult(validationResult);
    }
}
