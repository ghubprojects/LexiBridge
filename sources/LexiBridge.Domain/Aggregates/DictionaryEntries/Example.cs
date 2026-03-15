using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.DictionaryEntries;

public sealed class Example : Entity<Guid>
{
    public string Text { get; private set; } = default!;

    private Example() { }

    private Example(string text)
    {
        Text = text;
    }

    internal static Example Create(string text)
    {
        return new Example(text);
    }
}