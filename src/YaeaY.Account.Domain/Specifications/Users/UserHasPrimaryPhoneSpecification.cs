using YaeaY.Account.Domain.Entities.AggregateRoots.Users;

namespace YaeaY.Account.Domain.Specifications.Users;

public sealed class UserHasPrimaryPhoneSpecification
{
    public bool IsSatisfiedBy(User user)
    {
        return user.Phones.Any(phone => phone.IsPrimary);
    }
}
