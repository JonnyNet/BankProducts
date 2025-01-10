namespace BankProducts.Domain.Models;

public record ProductModel(string CustomerId, ProductTypeEnum ProductType, decimal Amount, float InterestRate);

