using BankProducts.Domain.Exceptions;

namespace BankProducts.Domain.Specifications;

public abstract class Specification<T>
{
    public abstract string ErrorMessage { get; protected set; }
    protected abstract Func<T, Task<bool>> Delegate { get; }
    public Task<bool> IsSatisfiedBy(T candidate)
    {
        return Delegate(candidate);
    }

    public static async Task ValidateRules(IEnumerable<Specification<T>> specifications, T candidate)
    {
        foreach (Specification<T> specification in specifications)
        {
            bool result = await specification.IsSatisfiedBy(candidate);
            if (!result)
            {
                throw new DomainException(specification.ErrorMessage);
            }
        }
    }
}
