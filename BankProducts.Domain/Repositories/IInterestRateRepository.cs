namespace BankProducts.Domain.Repositories;

public interface IInterestRateRepository
{
    Task<float> GetCurrent();
}
