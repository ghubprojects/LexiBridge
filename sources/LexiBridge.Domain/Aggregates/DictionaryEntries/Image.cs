using LexiBridge.Domain.Aggregates.DictionaryEntries.Enums;
using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.DictionaryEntries;

public sealed class Image : Entity<Guid>
{
    public string Url { get; private set; } = default!;
    public ImageSource Source { get; private set; }

    private Image() { }

    private Image(string url, ImageSource source)
    {
        Id = Guid.CreateVersion7();
        Url = url;
        Source = source;
    }

    internal static Image Create(string url, ImageSource source)
    {
        return new Image(url, source);
    }
}
