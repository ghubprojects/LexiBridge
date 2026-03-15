using LexiBridge.Shared.Results;

namespace LexiBridge.Domain.Aggregates.LearningItems.Errors;

public static class LearningItemErrors
{
    public static readonly Error NotFound =
        new("LearningItem.NotFound", ErrorType.NotFound);

    public static readonly Error DeckNotFound =
        new("LearningItem.DeckNotFound", ErrorType.NotFound);

    public static readonly Error InvalidHeadword =
        new("LearningItem.InvalidHeadword", ErrorType.Validation);
}