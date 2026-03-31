using YaeaY.Account.Domain.Abstraction.Interfaces;

namespace YaeaY.Account.Domain.Repositories;

public interface IRepository<T> where T : IAggregateRoot { }
