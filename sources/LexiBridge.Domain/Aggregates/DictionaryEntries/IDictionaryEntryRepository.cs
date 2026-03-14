using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.DictionaryEntries;

public interface IDictionaryEntryRepository : IRepository<DictionaryEntry, Guid>
{
    Task<DictionaryEntry?> FindByHeadwordAsync(
        string headword,
        PartOfSpeech partOfSpeech,
        CancellationToken cancellationToken);
}