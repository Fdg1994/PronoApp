using Core.Application.Contracts.Persistence;
using Core.Domain.Entities;

namespace core.application.contracts.persistence
{
    public interface IEventRepository : IAsyncRepository<EventEntity>
    {
    }
}