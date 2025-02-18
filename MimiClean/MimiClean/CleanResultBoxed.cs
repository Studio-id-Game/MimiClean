namespace StudioIdGames.MimiClean
{
    public class CleanResultBoxed<TResult> : ICleanResultBoxed
    {
        public CleanResultBoxed(CleanResultState state, TResult result, CleanResultError error)
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

        public CleanResultState TryGetValue(out TResult result)
        {
            result = Result;
            return State;
        }

        public CleanResult<TResult> Unbox() => new CleanResult<TResult>(State, Result, Error);

        public override string ToString()
        {
            var stateText = IsSuccess ? "Success" : IsFailed ? $"Failed: {Error?.Message ?? "<unknown error>"}" : "Canceled";
            var resultText = Result.ToString() ?? "<null>";
            return $"[{stateText}] {resultText}";
        }

        public static bool operator true(CleanResultBoxed<TResult> t) { return t.State == CleanResultState.Success; }

        public static bool operator false(CleanResultBoxed<TResult> t) { return t.State != CleanResultState.Success; }
    }

}
