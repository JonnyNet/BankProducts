using BankProducts.Domain.Aggregates;
using BankProducts.Domain.Repositories;

namespace BankProducts.Infrastructure.Repositories;

internal class ProductRepository(BankContext dbContext) : IProductRepository
{
    public async Task Create(ProductAggegate product)
    {
        await dbContext.Products.AddAsync(new(
            product.Id,
            product.CustomerId,
            product.ProductType.Id,
            product.Amount,
            product.InterestRate,
            (short)product.Status,
            product.CreatedOn,
            product.LastModifiedOn));

        await dbContext.SaveChangesAsync();
    }

    public async Task<CustomerProductEntity?> GetProduct(short productTypeId, Guid ProductId)
    {
        IQueryable<CustomerProductEntity> query = from p in dbContext.Products
                                                  join c in dbContext.Customers on p.CustomerId equals c.Id
                                                  where p.ProductType == productTypeId && p.Id == ProductId && p.Status == 1
                                                  select new CustomerProductEntity(
                                                      p.Id,
                                                      p.CustomerId,
                                                      c.Name,
                                                      c.Phone,
                                                      c.Email,
                                                      p.ProductType,
                                                      p.Amount,
                                                      p.InterestRate,
                                                      p.Status,
                                                      p.CreatedOn,
                                                      p.LastModifiedOn);

        CustomerProductEntity? entity = await query.FirstOrDefaultAsync();
        return entity;
    }

    public async Task<CustomerProductEntity?> GetProduct(short productTypeId, string customerId)
    {
        IQueryable<CustomerProductEntity> query = from p in dbContext.Products
                                                  join c in dbContext.Customers on p.CustomerId equals c.Id
                                                  where p.ProductType == productTypeId && p.CustomerId == customerId && p.Status == 1
                                                  select new CustomerProductEntity(
                                                      p.Id,
                                                      p.CustomerId,
                                                      c.Name,
                                                      c.Phone,
                                                      c.Email,
                                                      p.ProductType,
                                                      p.Amount,
                                                      p.InterestRate,
                                                      p.Status,
                                                      p.CreatedOn,
                                                      p.LastModifiedOn);

        CustomerProductEntity? entity = await query.FirstOrDefaultAsync();
        return entity;
    }

    public async Task Update(ProductAggegate product)
    {
        ProductEntity updatedProduct = new(
            product.Id,
            product.CustomerId,
            product.ProductType.Id,
            product.Amount,
            product.InterestRate,
            (short)product.Status,
            product.CreatedOn,
            product.LastModifiedOn);

        dbContext.Products.Attach(updatedProduct);

        dbContext.Entry(updatedProduct).Property(p => p.Amount).IsModified = true;
        dbContext.Entry(updatedProduct).Property(p => p.Status).IsModified = true;
        dbContext.Entry(updatedProduct).Property(p => p.LastModifiedOn).IsModified = true;

        await dbContext.SaveChangesAsync();
    }
}
