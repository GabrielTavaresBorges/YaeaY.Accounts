using YaeaY.Account.Domain.ValueObjects.Securities;

namespace YaeaY.Account.Application.Services.Security.Interfaces;

public interface IEmailConfirmationTokenService
{
    Task<GeneratedEmailConfirmationToken> GenerateTokenAsync();
}
