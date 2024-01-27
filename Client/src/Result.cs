public class Result<TSuccess, TFailure>
{
    public TSuccess Value { get; }
    public bool IsSuccess { get; }
    public TFailure? Error { get; }

    private Result(TSuccess value)
    {
        Value = value;
        IsSuccess = true;
        Error = default;
    }

    private Result(TFailure error)
    {
        Error = error;
        Value = default!;
        IsSuccess = false;
    }

    public static Result<TSuccess, TFailure> Success(TSuccess value) => new Result<TSuccess, TFailure>(value);
    public static Result<TSuccess, TFailure> Failure(TFailure error) => new Result<TSuccess, TFailure>(error);
}