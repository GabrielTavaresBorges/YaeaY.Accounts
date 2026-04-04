using FluentAssertions;
using YaeaY.Account.Domain.ValueObjects.Securities;

namespace YaeaY.Account.Domain.UnitTests.ValueObjects.Securities.PlainPasswordTests;

public class PlainPasswordCreateTests
{
    // IsFailure

    [Fact]
    public void Create_WhenPlainPasswordIsNull_ShouldFailure()
    {
        // Arrange

        string plainPassword = null!;

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_NULL_EMPTY_WHITE_SPACE");
        result.Error.Message.Should().Be("Password cannot be null, empty or white space.");
    }

    [Fact]
    public void Create_WhenPlainPasswordIsEmpty_ShouldFailure()
    {
        // Arrange

        string plainPassword = string.Empty;

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_NULL_EMPTY_WHITE_SPACE");
        result.Error.Message.Should().Be("Password cannot be null, empty or white space.");
    }

    [Fact]
    public void Create_WhenPlainPasswordContainsWhiteSpace_ShouldFailure()
    {
        // Arrange

        string plainPassword = " ";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_NULL_EMPTY_WHITE_SPACE");
        result.Error.Message.Should().Be("Password cannot be null, empty or white space.");
    }

    [Fact]
    public void Create_WhenPlainPasswordIsTooShort_ShouldFailure()
    {
        // Arrange

        string plainPassword = "Ab1@abc";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_TOO_SHORT");
        result.Error.Message.Should().Be("Password must be at least 8 chars.");
    }

    [Fact]
    public void Create_WhenPlainPasswordDoesNotContainUppercase_ShouldFailure()
    {
        // Arrange

        string plainPassword = "abc123@x";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_MISSING_UPPERCASE");
        result.Error.Message.Should().Be("Password must contain at least one uppercase letter.");
    }

    [Fact]
    public void Create_WhenPlainPasswordDoesNotContainLowercase_ShouldFailure()
    {
        // Arrange

        string plainPassword = "ABC123@X";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_MISSING_LOWERCASE");
        result.Error.Message.Should().Be("Password must contain at least one lowercase letter.");
    }

    [Fact]
    public void Create_WhenPlainPasswordDoesNotContainDigit_ShouldFailure()
    {
        // Arrange

        string plainPassword = "Abcdef@X";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_MISSING_DIGIT");
        result.Error.Message.Should().Be("Password must contain at least one number.");
    }

    [Fact]
    public void Create_WhenPlainPasswordDoesNotContainSpecialCharacter_ShouldFailure()
    {
        // Arrange

        string plainPassword = "Abcdef12";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_MISSING_SPECIAL");
        result.Error.Message.Should().Be("Password must contain at least one special character.");
    }

    [Fact]
    public void Create_WhenPlainPasswordIsTooLong_ShouldFailure()
    {
        // Arrange

        string plainPassword = "Aa1@" + new string('b', 253);

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("PASSWORD_TOO_LONG");
        result.Error.Message.Should().Be("Password is too long. Maximum allowed length is 256 characters.");
    }

    // IsSuccess

    [Fact]
    public void Create_WhenPlainPasswordIsValid_ShouldSuccess()
    {
        // Arrange

        string plainPassword = "Abc123@x";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Password.Should().Be("Abc123@x");
    }

    [Fact]
    public void Create_WhenPlainPasswordHasLeadingOrTrailingSpaces_ShouldSucceed()
    {
        // Arrange

        string plainPassword = " Abc123@x ";

        // Act

        var result = PlainPassword.Create(plainPassword);

        // Assert

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Password.Should().Be("Abc123@x");
    }
}
