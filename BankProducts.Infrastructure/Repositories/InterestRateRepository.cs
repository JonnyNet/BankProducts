using BankProducts.Domain.Repositories;

namespace BankProducts.Infrastructure.Repositories;

internal class InterestRateRepository : IInterestRateRepository
{
    public Task<float> GetCurrent()
    {
        return Task.FromResult(0.04f);
    }
}
