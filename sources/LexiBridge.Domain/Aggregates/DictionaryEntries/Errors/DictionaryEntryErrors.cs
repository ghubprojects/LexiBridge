using LexiBridge.Shared.Results;

namespace LexiBridge.Domain.Aggregates.DictionaryEntries.Errors;

public static class DictionaryEntryErrors
{
    public static readonly Error NotFound = 
        new("DictionaryEntry.NotFound", ErrorType.NotFound);
}
