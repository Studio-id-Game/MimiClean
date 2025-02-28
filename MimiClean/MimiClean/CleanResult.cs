namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを提供します。
    /// 特に、戻り値が無い<see cref="CleanResult{TResult}"/>を表現する為のユーティリティークラスです。
    /// </summary>
    public static class CleanResult
    {
        /// <summary>
        /// 戻り値の無い型を表現するためのダミー構造体
        /// </summary>
        public readonly struct Void
        { }

        /// <summary>
        /// 操作の成功を通知する、戻り値の無いオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<Void> Success() => CleanResult<Void>.Success(default);

        /// <summary>
        /// 操作の中断を通知する、戻り値の無いオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<Void> Canceled() => CleanResult<Void>.Canceled(default);

        /// <summary>
        /// 操作の失敗を通知する、戻り値の無いオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<Void> Failed(CleanResultError error) => CleanResult<Void>.Failed(error);
    }

    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを提供します。
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public readonly ref struct CleanResult<TResult>
    {
        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResult(CleanResultState state, TResult result, CleanResultError error)
        {
            State = state;
            Result = result;
            Error = error;
        }

        /// <summary>
        /// 操作の状態を表します
        /// </summary>
        public CleanResultState State { get; }

        /// <summary>
        /// 操作に失敗していない場合、操作の結果の戻り値を表します
        /// </summary>
        public TResult Result { get; }

        /// <summary>
        /// 操作に失敗している場合、エラーの内容を表します
        /// </summary>
        public CleanResultError Error { get; }

        /// <summary>
        /// 操作が成功した場合のみtrueです。
        /// </summary>
        public bool IsSuccess => State == CleanResultState.Success;

        /// <summary>
        /// 操作が中断した場合のみtrueです。
        /// </summary>
        public bool IsCanceled => State == CleanResultState.Canceled;

        /// <summary>
        /// 操作が失敗した場合のみtrueです。
        /// </summary>
        public bool IsFailed => State == CleanResultState.Failed;

        /// <summary>
        /// 状態をチェックしながら操作の戻り値を取り出します。
        /// </summary>
        /// <param name="result">操作の戻り値が代入されます</param>
        /// <returns>操作の状態を表します</returns>
        public CleanResultState TryGetValue(out TResult result)
        {
            result = Result;
            return State;
        }

        /// <summary>
        /// 戻り値を捨てたCleanResultを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<CleanResult.Void> AsVoid()
        {
            return new CleanResult<CleanResult.Void>(State, default, Error);
        }

        /// <summary>
        /// object型戻り値のCleanResultに変換したものを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<object> AsObject()
        {
            return new CleanResult<object>(State, Result, Error);
        }

        /// <summary>
        /// 新しい<see cref="T"/>型戻り値のCleanResultを新しく作成します。
        /// </summary>
        /// <typeparam name="T">新しい型</typeparam>
        /// <param name="result">新しいResult</param>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<T> As<T>(T result)
        {
            return new CleanResult<T>(State, result, Error);
        }

        /// <summary>
        /// <see cref="T"/>型戻り値のCleanResultに変換したものを新しく作成します。
        /// Resultは自動でキャストされますが、キャストに失敗した場合CleanResultの状態はFailedになります。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<T> As<T>()
        {
            return Result is T resultT ? As(resultT) : CleanResult<T>.Failed(new CleanResultCastError(typeof(TResult), typeof(T)));
        }

        /// <summary>
        /// List等で扱えるように、値を専用のBox型に変換します。
        /// </summary>
        /// <returns>Box化したオブジェクト</returns>
        public CleanResultBoxed<TResult> Box() => new CleanResultBoxed<TResult>(State, Result, Error);

        public override string ToString()
        {
            var stateText = IsSuccess ? "Success" : IsFailed ? $"Failed: {Error?.Message ?? "<unknown error>"}" : "Canceled";
            var resultText = Result.ToString() ?? "<null>";
            return $"[{stateText}] {resultText}";
        }

        public static bool operator true(in CleanResult<TResult> t)
        { return t.State == CleanResultState.Success; }

        public static bool operator false(in CleanResult<TResult> t)
        { return t.State != CleanResultState.Success; }

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">戻り値</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResult<TResult> Success(TResult result) => new CleanResult<TResult>(CleanResultState.Success, result, null);

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">省略可能な戻り値</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResult<TResult> Canceled(TResult result = default) => new CleanResult<TResult>(CleanResultState.Canceled, result, null);

        /// <summary>
        /// 操作の失敗を通知する、エラー内容を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="error">エラー内容</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResult<TResult> Failed(CleanResultError error) => new CleanResult<TResult>(CleanResultState.Failed, default, error);
    }
}
