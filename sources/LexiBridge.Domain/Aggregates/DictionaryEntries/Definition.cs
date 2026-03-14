using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.DictionaryEntries;

public sealed class Definition : Entity<Guid>
{
    public string Text { get; private set; } = default!;
    public int OrderIndex { get; private set; }

    private readonly List<Example> _examples = [];
    public IReadOnlyCollection<Example> Examples => _examples.AsReadOnly();

    private Definition() { }

    private Definition(string definition, int orderIndex)
    {
        Text = definition;
        OrderIndex = orderIndex;
    }

    internal static Definition Create(string definition, int orderIndex)
    {
        return new Definition(definition, orderIndex);
    }

    internal void AddExample(string text)
    {
        _examples.Add(Example.Create(text));
    }
}