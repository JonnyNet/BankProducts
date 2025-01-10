using BankProducts.Domain.Services;
using BankProducts.Domain.Services.Actions;
using BankProducts.Domain.Services.ProductTypes;
using BankProducts.Domain.Services.TransactionStrategies;
using BankProducts.Domain.Services.TransactionStrategies.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BankProducts.Domain;

public static class DependencyContainer
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();

        services.AddTransient<ITransactionContext, TransactionContext>();
        services.AddTransient<ITransactionStrategy, DepositStrategy>();
        services.AddTransient<ITransactionStrategy, WithdrawStrategy>();

        services.AddTransient<IProduct, SavingsAccount>();
        services.AddTransient<ITransactional, SavingsAccount>();
        services.AddTransient<IInterestable, SavingsAccount>();

        services.AddTransient<IProduct, CheckingAccount>();
        services.AddTransient<ITransactional, CheckingAccount>();
        services.AddTransient<ICancelable, CheckingAccount>();

        services.AddTransient<ICancelable, CertificateDeposit>();
        services.AddTransient<IInterestable, CertificateDeposit>();
        services.AddTransient<IProduct, CertificateDeposit>();

        return services;
    }
}
