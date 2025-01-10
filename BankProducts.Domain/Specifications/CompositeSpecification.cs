using BankProducts.Domain.Exceptions;

namespace BankProducts.Domain.Specifications;

public class CompositeSpecification<T>(params Specification<T>[] specifications) : Specification<T>
{
    private readonly IList<Specification<T>> _specifications = [.. specifications];
    public override string ErrorMessage { get; protected set; } = "Composite specification failed.";

    protected override Func<T, Task<bool>> Delegate => async candidate =>
    {
        foreach (Specification<T> specification in _specifications)
        {
            bool result = await specification.IsSatisfiedBy(candidate);
            if (!result)
            {
                ErrorMessage = specification.ErrorMessage;
                return false;
            }
        }
        return true;
    };

    public async Task ExecuteAsync(T candidate)
    {
        bool result = await IsSatisfiedBy(candidate);
        if (!result)
        {
            throw new DomainException(ErrorMessage);
        }
    }
}
