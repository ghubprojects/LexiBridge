using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.LearningItems;

public interface ILearningItemRepository : IRepository<LearningItem, Guid>
{
    Task<LearningItem?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        LearningItem learningItem,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        LearningItem learningItem,
        CancellationToken cancellationToken = default);
}