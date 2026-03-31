using YaeaY.Account.Domain.Abstraction.Records;

namespace YaeaY.Account.Domain.Abstraction.Exceptions;

public class DomainException : Exception
{
    public string? Identifier { get; }

    public DomainException(string message, string? identifier = null)
         : base(message)
    {
        Identifier = identifier;
    }

    public DomainException(Error error) : base(error.Message)
    {
        Identifier = error.Identifier;
    }
}
