using System.Text.RegularExpressions;
using YaeaY.Account.Domain.Abstraction.Records;

namespace YaeaY.Account.Domain.ValueObjects.Securities;

public sealed record PlainPassword
{
    private string _password = string.Empty;

    public string Password => _password;

    private PlainPassword(string password)
    {
        _password = password;
    }

    private static readonly Regex UppercaseRegex = new("[A-Z]", RegexOptions.Compiled);
    private static readonly Regex LowercaseRegex = new("[a-z]", RegexOptions.Compiled);
    private static readonly Regex DigitRegex = new(@"\d", RegexOptions.Compiled);
    private static readonly Regex SpecialRegex = new("[^A-Za-z0-9]", RegexOptions.Compiled);

    public static Result<PlainPassword> Create(string password)
    {
        var validatedPlainPassword = ValidatePlainPassword(password);

        if (validatedPlainPassword.IsFailure)
            return Result<PlainPassword>.Failure(validatedPlainPassword.Error);

        var plainPassword = new PlainPassword(validatedPlainPassword.Value);

        return Result<PlainPassword>.Success(plainPassword);
    }

    private static Result<string> ValidatePlainPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return Result<string>.Failure(new Error(
               Identifier: "PASSWORD_NULL_EMPTY_WHITE_SPACE",
               Message: "Password cannot be null, empty or white space."));
        }

        password = password.Trim();

        if (password.Length < 8)
        {
            return Result<string>.Failure(new Error(
             Identifier: "PASSWORD_TOO_SHORT",
             Message: "Password must be at least 8 chars."));
        }

        if (!UppercaseRegex.IsMatch(password))
        {
            return Result<string>.Failure(new Error(
                Identifier: "PASSWORD_MISSING_UPPERCASE",
                Message: "Password must contain at least one uppercase letter."));
        }

        if (!LowercaseRegex.IsMatch(password))
        {
            return Result<string>.Failure(new Error(
                Identifier: "PASSWORD_MISSING_LOWERCASE",
                Message: "Password must contain at least one lowercase letter."));
        }

        if (!DigitRegex.IsMatch(password))
        {
            return Result<string>.Failure(new Error(
                Identifier: "PASSWORD_MISSING_DIGIT",
                Message: "Password must contain at least one number."));
        }

        if (!SpecialRegex.IsMatch(password))
        {
            return Result<string>.Failure(new Error(
                Identifier: "PASSWORD_MISSING_SPECIAL",
                Message: "Password must contain at least one special character."));
        }

        const int MaxLength = 256;
        if (password.Length > MaxLength)
        {
            return Result<string>.Failure(new Error(
                Identifier: "PASSWORD_TOO_LONG",
                Message: $"Password is too long. Maximum allowed length is {MaxLength} characters."));
        }

        return Result<string>.Success(password);
    }
}