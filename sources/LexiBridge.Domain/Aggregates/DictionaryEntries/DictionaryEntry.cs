using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.DictionaryEntries;

public class DictionaryEntry : AggregateRoot<Guid>
{
    public string Headword { get; private set; } = default!;
    public PartOfSpeech PartOfSpeech { get; private set; }
    public DictionarySource Source { get; private set; }

    private readonly List<Pronunciation> _pronunciations = [];
    public IReadOnlyCollection<Pronunciation> Pronunciations => _pronunciations.AsReadOnly();

    private readonly List<Definition> _definitions = [];
    public IReadOnlyCollection<Definition> Definitions => _definitions.AsReadOnly();

    private readonly List<Image> _images = [];
    public IReadOnlyCollection<Image> Images => _images.AsReadOnly();

    private DictionaryEntry() { }

    private DictionaryEntry(string headword, PartOfSpeech partOfSpeech, DictionarySource source)
    {
        Id = Guid.CreateVersion7();
        Headword = headword;
        PartOfSpeech = partOfSpeech;
        Source = source;
    }

    public static DictionaryEntry Create(string headword, PartOfSpeech partOfSpeech, DictionarySource source)
    {
        return new DictionaryEntry(headword, partOfSpeech, source);
    }

    public void AddPronunciation(string ipa, Accent accent, string audioUrl, AudioSource audioSource)
    {
        _pronunciations.Add(Pronunciation.Create(ipa, accent, audioUrl, audioSource));
    }

    public void AddDefinition(string text, IEnumerable<string> examples)
    {
        var orderIndex = _definitions.Count + 1;
        var definition = Definition.Create(text, orderIndex);

        foreach (var example in examples)
            definition.AddExample(example);

        _definitions.Add(definition);
    }

    public void AddImage(string url, ImageSource source)
    {
        _images.Add(Image.Create(url, source));
    }
}
