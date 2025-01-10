using BankProducts.Domain.Repositories;
using BankProducts.Infrastructure.Repositories;

namespace BankProducts.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddDbContext<BankContextFactory>();
        services.AddDbContext<BankContext>(options
            => options.UseSqlServer(configuration.GetConnectionString(connectionString)));

        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<BankContext>());
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IInterestRateRepository, InterestRateRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();

        return services;
    }

    public static IApplicationBuilder RunMigrationsRepositories(this IApplicationBuilder app)
    {
        using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            BankContextFactory context = serviceScope.ServiceProvider.GetRequiredService<BankContextFactory>();
            context.Database.Migrate();
        }
        return app;
    }
}
