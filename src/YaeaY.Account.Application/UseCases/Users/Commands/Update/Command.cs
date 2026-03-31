using MediatR;
using YaeaY.Account.Domain.Abstraction.Records;
using YaeaY.Account.Domain.ValueObjects.Dates;

namespace YaeaY.Account.Application.UseCases.Users.Commands.Update;

public sealed record Command(
    Guid Id,
    string? Email,
    string? Password,
    string? UserName,
    BirthDate? BirthDate
    ) : IRequest<Result<Response>>
{

}