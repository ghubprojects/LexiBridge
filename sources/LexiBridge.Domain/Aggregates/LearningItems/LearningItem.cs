using LexiBridge.Domain.Aggregates.DictionaryEntries;
using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.LearningItems;

public sealed class LearningItem : AggregateRoot<Guid>, IAuditableEntity, ISoftDeleteEntity
{
    // References
    public Guid DeckId { get; private set; }
    public Guid CardTemplateId { get; private set; }
    public Guid? DictionaryEntryId { get; private set; }

    // Core vocabulary
    public string Headword { get; private set; } = default!;
    public PartOfSpeech PartOfSpeech { get; private set; }
    public Accent Accent { get; private set; }
    public string Ipa { get; private set; } = default!;

    // Learning content
    public string Definition { get; private set; } = default!;
    public string Translation { get; private set; } = default!;
    public string Example { get; private set; } = default!;
    public string Cloze { get; private set; } = default!;

    // Media
    public string? AudioUrl { get; private set; } = default!;
    public string? ImageUrl { get; private set; } = default!;

    // Examples
    private readonly List<LearningExample> _examples = [];
    public IReadOnlyCollection<LearningExample> Examples => _examples.AsReadOnly();

    #region Audit

    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }
    public DateTimeOffset? LastModifiedAt { get; }
    public Guid? LastModifiedBy { get; }

    #endregion

    #region Soft Delete

    public bool IsDeleted { get; }
    public DateTimeOffset? DeletedAt { get; }
    public Guid? DeletedBy { get; }

    #endregion

    private LearningItem() { }

    private LearningItem(
        Guid deckId,
        Guid cardTemplateId,
        string headword,
        PartOfSpeech partOfSpeech,
        Accent accent,
        string ipa,
        string definition,
        string translation,
        string example,
        string cloze,
        string? audioUrl,
        string? imageUrl,
        Guid? dictionaryEntryId)
    {
        Id = Guid.CreateVersion7();

        DeckId = deckId;
        CardTemplateId = cardTemplateId;
        DictionaryEntryId = dictionaryEntryId;

        Headword = headword;
        PartOfSpeech = partOfSpeech;
        Accent = accent;
        Ipa = ipa;

        Definition = definition;
        Translation = translation;
        Example = example;
        Cloze = cloze;

        AudioUrl = audioUrl;
        ImageUrl = imageUrl;
    }


    public static LearningItem Create(
        Guid deckId,
        Guid cardTemplateId,
        string headword,
        PartOfSpeech partOfSpeech,
        Accent accent,
        string ipa,
        string definition,
        string translation,
        string example,
        string cloze,
        string? audioUrl = null,
        string? imageUrl = null,
        Guid? dictionaryEntryId = null)
    {
        return new LearningItem(
            deckId,
            cardTemplateId,
            headword,
            partOfSpeech,
            accent,
            ipa,
            definition,
            translation,
            example,
            cloze,
            audioUrl,
            imageUrl,
            dictionaryEntryId);
    }

    public void AddExample(string text)
    {
        _examples.Add(LearningExample.Create(text));
    }
}