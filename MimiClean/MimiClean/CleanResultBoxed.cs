namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>をBox化する為のクラス
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class CleanResultBoxed<TResult> : ICleanResultBoxed
    {
        /// <summary>
        /// <see cref="CleanResultBoxed{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResultBoxed(CleanResultState state, TResult result, CleanResultError error)
        {
            State = state;
            Result = result;
            Error = error;
        }

        /// <inheritdoc cref="CleanResult{TResult}.State"/>
        public CleanResultState State { get; }

        /// <inheritdoc cref="CleanResult{TResult}.Result"/>
        public TResult Result { get; }

        /// <inheritdoc cref="CleanResult{TResult}.Error"/>
        public CleanResultError Error { get; }

        /// <inheritdoc cref="CleanResult{TResult}.IsSuccess"/>
        public bool IsSuccess => State == CleanResultState.Success;

        /// <inheritdoc cref="CleanResult{TResult}.IsCanceled"/>
        public bool IsCanceled => State == CleanResultState.Canceled;

        /// <inheritdoc cref="CleanResult{TResult}.IsFailed"/>
        public bool IsFailed => State == CleanResultState.Failed;

        /// <inheritdoc cref="CleanResult{TResult}.TryGetValue"/>
        public CleanResultState TryGetValue(out TResult result)
        {
            result = Result;
            return State;
        }

        /// <summary>
        /// 値のBox型か解除し、ref struct 構造体に変換します。
        /// </summary>
        /// <returns>ref struct 化したオブジェクト</returns>
        public CleanResult<TResult> Unbox() => new CleanResult<TResult>(State, Result, Error);

        public override string ToString()
        {
            var stateText = IsSuccess ? "Success" : IsFailed ? $"Failed: {Error?.Message ?? "<unknown error>"}" : "Canceled";
            var resultText = Result.ToString() ?? "<null>";
            return $"[{stateText}] {resultText}";
        }

        public static bool operator true(CleanResultBoxed<TResult> t)
        { return t.State == CleanResultState.Success; }

        public static bool operator false(CleanResultBoxed<TResult> t)
        { return t.State != CleanResultState.Success; }
    }
}
