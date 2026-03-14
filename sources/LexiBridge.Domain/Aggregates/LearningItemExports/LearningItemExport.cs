using LexiBridge.Domain.SeedWork;

namespace LexiBridge.Domain.Aggregates.LearningItemExports;

public sealed class LearningItemExport : AggregateRoot<Guid>
{
    public Guid LearningItemId { get; private set; }
    public ExportDestination Provider { get; private set; }
    public ExportStatus Status { get; private set; }
    public int Attempts { get; private set; }
    public string? ExternalId { get; private set; }
    public string? Error { get; private set; }
    public DateTimeOffset? ExportedAt { get; private set; }

    private LearningItemExport() { }

    private LearningItemExport(Guid learningItemId, ExportDestination provider)
    {
        Id = Guid.CreateVersion7();
        LearningItemId = learningItemId;
        Provider = provider;
        Status = ExportStatus.Pending;
        Attempts = 0;
    }

    public static LearningItemExport Create(Guid learningItemId, ExportDestination provider)
    {
        return new LearningItemExport(learningItemId, provider);
    }

    public void MarkProcessing()
    {
        if (Status == ExportStatus.Success)
            throw new InvalidOperationException("Export already succeeded.");

        Status = ExportStatus.Processing;
        Attempts++;
        Error = null;
    }

    public void MarkSuccess(string externalId)
    {
        if (Status != ExportStatus.Processing)
            throw new InvalidOperationException("Export must be processing before success.");

        Status = ExportStatus.Success;
        ExternalId = externalId;
        ExportedAt = DateTimeOffset.UtcNow;
        Error = null;
    }

    public void MarkFailed(string error)
    {
        if (Status != ExportStatus.Processing)
            throw new InvalidOperationException("Export must be processing before failing.");

        Status = ExportStatus.Failed;
        Error = error;
    }
}
