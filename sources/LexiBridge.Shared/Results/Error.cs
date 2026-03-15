namespace LexiBridge.Shared.Results;

public sealed record Error(string Code, ErrorType Type = ErrorType.Failure)
{
    public static readonly Error None = new(string.Empty, ErrorType.None);
}