namespace StudioIdGames.MimiClean
{
    public static class CleanResult
    {
        public readonly struct Void { }

        public static CleanResult<Void> Success() => CleanResult<Void>.Success(default);

        public static CleanResult<Void> Canceled() => CleanResult<Void>.Canceled(default);

        public static CleanResult<Void> Failed(CleanResultError error) => CleanResult<Void>.Failed(error);
    }

    public readonly ref struct CleanResult<TResult>
    {
        public CleanResult(CleanResultState state, TResult result, CleanResultError error)
        {
            State = state;
            Result = result;
            Error = error;
        }

        public CleanResultState State { get; }

        public TResult Result { get; }

        public CleanResultError Error { get; }

        public bool IsSuccess => State == CleanResultState.Success;

        public bool IsCanceled => State == CleanResultState.Canceled;

        public bool IsFailed => State == CleanResultState.Failed;

        public CleanResultState TryGet(out TResult result)
        {
            result = Result;
            return State;
        }

        public CleanResult<CleanResult.Void> AsVoid()
        {
            return new CleanResult<CleanResult.Void>(State, default, Error);
        }

        public CleanResult<object> AsObject()
        {
            return new CleanResult<object>(State, Result, Error);
        }

        public CleanResult<T> As<T>(T result)
        {
            return new CleanResult<T>(State, result, Error);
        }

        public CleanResult<T> As<T>()
        {
            return Result is T resultT ? As(resultT) : As<T>(default);
        }

        public static bool operator true(CleanResult<TResult> t) { return t.State == CleanResultState.Success; }

        public static bool operator false(CleanResult<TResult> t) { return t.State != CleanResultState.Success; }

        public static CleanResult<TResult> Success(TResult result) => new CleanResult<TResult>(CleanResultState.Success, result, null);

        public static CleanResult<TResult> Canceled(TResult result = default) => new CleanResult<TResult>(CleanResultState.Canceled, result, null);

        public static CleanResult<TResult> Failed(CleanResultError error) => new CleanResult<TResult>(CleanResultState.Failed, default, error);
    }
}

