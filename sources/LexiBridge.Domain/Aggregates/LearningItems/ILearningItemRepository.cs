using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.LearningItems;

public interface ILearningItemRepository : IRepository<LearningItem, Guid>
{
    Task<IReadOnlyList<LearningItem>> GetItemsAsync(CancellationToken cancellationToken);
}