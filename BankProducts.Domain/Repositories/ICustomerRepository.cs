namespace BankProducts.Domain.Repositories;

public interface ICustomerRepository
{
    Task<CustomerEntity?> GetById(string customerId);
}
