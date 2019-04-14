using Inf.Core.Domain;

namespace Inf.Core.Infrastructure
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
