using Core.Domain.Entities;

namespace Core.Application.Contracts.Persistence
{
    public interface IBetRepository : IAsyncRepository<BetEntity>
    {
    }
}