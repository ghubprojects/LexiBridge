using LexiBridge.Domain.Aggregates.LearningItemExports.Enums;
using LexiBridge.Domain.Aggregates.LearningItemExports.Errors;
using LexiBridge.Domain.SeedWork;
using LexiBridge.Shared.Results;

namespace LexiBridge.Domain.Aggregates.LearningItemExports;

public sealed class LearningItemExport : AggregateRoot<Guid>
{
    public Guid LearningItemId { get; private set; }
    public Guid CardTemplateId { get; private set; }

    public ExportDestination Destination { get; private set; }
    public ExportStatus Status { get; private set; }
    public int Attempts { get; private set; }
    public string? ExternalId { get; private set; }
    public string? Error { get; private set; }
    public DateTimeOffset? ExportedAt { get; private set; }

    private LearningItemExport() { }

    private LearningItemExport(Guid learningItemId, Guid cardTemplateId, ExportDestination destination)
    {
        Id = Guid.CreateVersion7();
        LearningItemId = learningItemId;
        CardTemplateId = cardTemplateId;
        Destination = destination;
        Status = ExportStatus.Pending;
        Attempts = 0;
    }

    public static LearningItemExport Create(Guid learningItemId, Guid cardTemplateId, ExportDestination destination)
    {
        return new LearningItemExport(learningItemId, cardTemplateId, destination);
    }

    public Result MarkProcessing()
    {
        if (Status == ExportStatus.Success)
            return Result.Failure(LearningItemExportErrors.AlreadySucceeded);

        Status = ExportStatus.Processing;
        Attempts++;
        Error = null;

        return Result.Success();
    }

    public Result MarkSuccess(string externalId)
    {
        if (Status != ExportStatus.Processing)
            return Result.Failure(LearningItemExportErrors.InvalidStatusForSuccess);

        Status = ExportStatus.Success;
        ExternalId = externalId;
        ExportedAt = DateTimeOffset.UtcNow;
        Error = null;

        return Result.Success();
    }

    public Result MarkFailed(string error)
    {
        if (Status != ExportStatus.Processing)
            return Result.Failure(LearningItemExportErrors.InvalidStatusForFailure);

        Status = ExportStatus.Failed;
        Error = error;

        return Result.Success();
    }
}
