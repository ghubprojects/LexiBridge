using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.LearningItems;

public sealed class LearningExample : Entity<Guid>, IAuditableEntity
{
    public string Text { get; private set; } = default!;

    #region Audit

    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }
    public DateTimeOffset? LastModifiedAt { get; }
    public Guid? LastModifiedBy { get; }

    #endregion

    private LearningExample() { }

    private LearningExample(string text)
    {
        Text = text;
    }

    internal static LearningExample Create(string text)
    {
        return new LearningExample(text);
    }
}