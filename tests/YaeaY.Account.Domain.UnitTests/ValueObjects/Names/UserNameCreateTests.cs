using FluentAssertions;
using YaeaY.Account.Domain.ValueObjects.Names;

namespace YaeaY.Account.Domain.UnitTests.ValueObjects.Names;

public class UserNameCreateTests
{
    // IsFailure

    [Fact]
    public void Create_WhenUserNameIsNull_ShouldFailure()
    {
        // Arrange

        string userName = null!;

        // Act

        var result = UserName.Create(userName);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("USER_NAME_NULL_EMPTY");
        result.Error.Message.Should().Be("Name cannot be null or empty.");
    }

    [Fact]
    public void Create_WhenUserNameHasLessThan2Characters_ShouldFailure()
    {
        // Arrange

        string userName = "A";

        // Act

        var result = UserName.Create(userName);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("USER_NAME_INVALID_LENGTH");
        result.Error.Message.Should().Be("Name must be between 2 and 100 characters.");
    }

    [Fact]
    public void Create_WhenUserNameHasMoreThan100Characters_ShouldFailure()
    {
        // Arrange

        string userName = new string('A', 101);

        // Act

        var result = UserName.Create(userName);

        // Assert

        result.IsFailure.Should().BeTrue();
        result.Error.Identifier.Should().Be("USER_NAME_INVALID_LENGTH");
        result.Error.Message.Should().Be("Name must be between 2 and 100 characters.");
    }

    // IsSuccess

    [Fact]
    public void Create_WhenUserNameIsValid_ShouldSuccess()
    {
        // Arrange

        string userName = "Example Name";

        // Act

        var result = UserName.Create(userName);

        // Assert

        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be("Example Name");
    }

    [Fact]
    public void Create_WhenUserNameHasLeadingOrTrailingSpaces_ShouldSuccess()
    {
        // Arrange

        string userName = " Example Name ";

        // Act

        var result = UserName.Create(userName);

        // Assert

        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be("Example Name");
    }
}
