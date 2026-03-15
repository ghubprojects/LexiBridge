using LexiBridge.Shared.Results;

namespace LexiBridge.Domain.Aggregates.LearningItemExports.Errors;

public static class LearningItemExportErrors
{
    public static readonly Error NotFound =
        new("LearningItemExport.NotFound", ErrorType.NotFound);

    public static readonly Error AlreadySucceeded =
        new("LearningItemExport.AlreadySucceeded", ErrorType.Conflict);

    public static readonly Error InvalidStatusForSuccess =
        new("LearningItemExport.InvalidStatusForSuccess", ErrorType.Conflict);

    public static readonly Error InvalidStatusForFailure =
        new("LearningItemExport.InvalidStatusForFailure", ErrorType.Conflict);
}