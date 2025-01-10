using BankProducts.Domain.Exceptions;

namespace BankProducts.Domain.Entities;

public record CustomerEntity(string Id, string Name, string Phone, string Email)
{
    public static async Task<CustomerEntity> BuildByIdAsync(ICustomerRepository customerRepository, string customerId)
    {
        CustomerEntity? customer = await customerRepository.GetById(customerId);

        if (customer == default)
        {
            throw new DomainException("EL cliente con id {0}, no existe.", customerId);
        }

        return customer;
    }
}
