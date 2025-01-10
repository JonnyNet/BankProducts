using BankProducts.Domain.Repositories;

namespace BankProducts.Infrastructure.Repositories;

internal class CustomerRepository(IDbContext dbContext) : ICustomerRepository
{
    public Task<CustomerEntity?> GetById(string customerId)
    {
        return dbContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
    }
}
