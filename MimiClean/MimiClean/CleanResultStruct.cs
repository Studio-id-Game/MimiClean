namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// 合計メモリ数が16バイト以上なら、<see cref="CleanResultBoxed{TResult}"/> または <see cref="CleanResult{TResult}"/> を利用するべきです。
    /// </summary>　
    public readonly struct CleanResultStruct<TResult> : ICleanResult<TResult>
    {
        /// <summary>
        /// <see cref="CleanResultStruct{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResultStruct(CleanResultState state, TResult result, CleanResultError error)
        {
            State = state;
            Result = result;
            Error = error;
        }

        /// <summary>
        /// <see cref="CleanResultStruct{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        public CleanResultStruct(CleanResultState state, TResult result)
        {
            State = state;
            Result = result;
            Error = null;
        }

        /// <summary>
        /// <see cref="CleanResultStruct{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResultStruct(CleanResultState state, CleanResultError error)
        {
            State = state;
            Result = default;
            Error = error;
        }

        /// <inheritdoc/>
        public CleanResultState State { get; }

        /// <inheritdoc/>
        public TResult Result { get; }

        object ICleanResult.Result => Result;

        /// <inheritdoc/>
        public CleanResultError Error { get; }

        /// <inheritdoc/>
        public bool IsSuccess => State == CleanResultState.Success;

        /// <inheritdoc/>
        public bool IsCanceled => State == CleanResultState.Canceled;

        /// <inheritdoc/>
        public bool IsFailed => State == CleanResultState.Failed;

        /// <inheritdoc/>
        public CleanResultState TryGetValue(out TResult result)
        {
            result = Result;
            return State;
        }

        /// <summary>
        /// 戻り値を捨てたCleanResultを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResultStruct<CleanResult.Void> AsVoid()
        {
            return new CleanResultStruct<CleanResult.Void>(State, default, Error);
        }

        /// <summary>
        /// object型戻り値のCleanResultに変換したものを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResultStruct<object> AsObject()
        {
            return new CleanResultStruct<object>(State, Result, Error);
        }

        /// <summary>
        /// 新しい<typeparamref name="T"/>型戻り値のCleanResultを新しく作成します。
        /// </summary>
        /// <typeparam name="T">新しい型</typeparam>
        /// <param name="result">新しいResult</param>
        /// <returns>新しいCleanResult</returns>
        public CleanResultStruct<T> As<T>(T result)
        {
            return new CleanResultStruct<T>(State, result, Error);
        }

        /// <summary>
        /// <typeparamref name="T"/>型戻り値のCleanResultに変換したものを新しく作成します。
        /// Resultは自動でキャストされますが、キャストに失敗した場合CleanResultの状態はFailedになります。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>新しいCleanResult</returns>
        public CleanResultStruct<T> As<T>()
        {
            return Result is T resultT ? As(resultT) : CleanResultStruct<T>.Failed(new CleanResultCastError(typeof(TResult), typeof(T)));
        }

        /// <summary>
        /// 値を専用の class 型に変換します。
        /// </summary>
        /// <returns>Box化したオブジェクト</returns>
        public CleanResultBoxed<TResult> Box() => new CleanResultBoxed<TResult>(this);

        /// <summary>
        /// 値を専用の ref struct 型に変換します。
        /// </summary>
        /// <returns>Box化したオブジェクト</returns>
        public CleanResult<TResult> Ref() => new CleanResult<TResult>(this);

        /// <inheritdoc/>
        public override string ToString()
        {
            var stateText = IsSuccess ? "Success" : IsFailed ? $"Failed: {Error?.Message ?? "<unknown error>"}" : "Canceled";
            var resultText = Result.ToString() ?? "<null>";
            return $"[{stateText}] {resultText}";
        }

        /// <summary>
        /// <see cref="State"/> が <see cref="CleanResultState.Success"/> の時、trueとして扱います。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator true(in CleanResultStruct<TResult> t)
        { return t.State == CleanResultState.Success; }

        /// <summary>
        /// <see cref="State"/> が <see cref="CleanResultState.Success"/> 以外の時、falseとして扱います。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator false(in CleanResultStruct<TResult> t)
        { return t.State != CleanResultState.Success; }

        /// <summary>
        /// <typeparamref name="TResult"/> への暗黙的変換を許可します。ただし、 <see cref="State"/> が <see cref="CleanResultState.Success"/> 以外の時は <see cref="System.InvalidCastException"/> をスローします。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static implicit operator TResult(in CleanResultStruct<TResult> t)
        {
            return t.State == CleanResultState.Success ? t.Result :
                throw new System.InvalidCastException($"Can't implcit cast when {nameof(Result)} is not {nameof(CleanResultState.Success)}");
        }

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">戻り値</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResultStruct<TResult> Success(TResult result)
        {
            return new CleanResultStruct<TResult>(CleanResultState.Success, result);
        }

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">省略可能な戻り値</param>
        /// <param name="error">省略可能なエラーオブジェクト</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResultStruct<TResult> Canceled(TResult result = default, CleanResultError error = null)
        {
            return new CleanResultStruct<TResult>(CleanResultState.Canceled, result, error);
        }

        /// <summary>
        /// 操作の失敗を通知する、エラー内容を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="error">エラー内容</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResultStruct<TResult> Failed(CleanResultError error)
        {
            return new CleanResultStruct<TResult>(CleanResultState.Failed, error);
        }
    }
}
