namespace BankProducts.Domain.Exceptions;

internal class DomainException : Exception
{
    public DomainException()
    { }

    public DomainException(string message)
        : base(message)
    { }

    public DomainException(string message, params object[] args)
        : base(string.Format(message, args))
    { }
    public DomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
