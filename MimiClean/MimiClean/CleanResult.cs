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

        /// <summary>
        /// 操作の成功を通知する、戻り値のあるオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<T> Success<T>(T value) => CleanResult<T>.Success(value);

        /// <summary>
        /// 操作の中断を通知する、戻り値のあるオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<T> Canceled<T>(T value) => CleanResult<T>.Canceled(value);

        /// <summary>
        /// 操作の失敗を通知する、戻り値のあるオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<T> Failed<T>(CleanResultError error) => CleanResult<T>.Failed(error);
    }

    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを提供します。
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public readonly ref struct CleanResult<TResult>
    {
        private readonly CleanResultStruct<TResult> _struct;

        internal CleanResult(CleanResultStruct<TResult> _struct)
        {
            this._struct = _struct;
        }

        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResult(CleanResultState state, TResult result, CleanResultError error)
        {
            _struct = new CleanResultStruct<TResult>(state, result, error);
        }

        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        public CleanResult(CleanResultState state, TResult result)
        {
            _struct = new CleanResultStruct<TResult>(state, result);
        }

        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResult(CleanResultState state, CleanResultError error)
        {
            _struct = new CleanResultStruct<TResult>(state, error);
        }

        /// <summary>
        /// 操作の状態を表します
        /// </summary>
        public CleanResultState State => _struct.State;

        /// <summary>
        /// 操作に失敗していない場合、操作の結果の戻り値を表します
        /// </summary>
        public TResult Result => _struct.Result;

        /// <summary>
        /// 操作に失敗している場合、エラーの内容を表します
        /// </summary>
        public CleanResultError Error => _struct.Error;

        /// <summary>
        /// 操作が成功した場合のみtrueです。
        /// </summary>
        public bool IsSuccess => _struct.IsSuccess;

        /// <summary>
        /// 操作が中断した場合のみtrueです。
        /// </summary>
        public bool IsCanceled => _struct.IsCanceled;

        /// <summary>
        /// 操作が失敗した場合のみtrueです。
        /// </summary>
        public bool IsFailed => _struct.IsFailed;

        /// <summary>
        /// 状態をチェックしながら操作の戻り値を取り出します。
        /// </summary>
        /// <param name="result">操作の戻り値が代入されます</param>
        /// <returns>操作の状態を表します</returns>
        public CleanResultState TryGetValue(out TResult result) => _struct.TryGetValue(out result);

        /// <summary>
        /// 戻り値を捨てたCleanResultを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<CleanResult.Void> AsVoid()
        {
            return new CleanResult<CleanResult.Void>(_struct.AsVoid());
        }

        /// <summary>
        /// object型戻り値のCleanResultに変換したものを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<object> AsObject()
        {
            return new CleanResult<object>(_struct.AsObject());
        }

        /// <summary>
        /// 新しい<typeparamref name="T"/>型戻り値のCleanResultを新しく作成します。
        /// </summary>
        /// <typeparam name="T">新しい型</typeparam>
        /// <param name="result">新しいResult</param>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<T> As<T>(T result)
        {
            return new CleanResult<T>(_struct.As(result));
        }

        /// <summary>
        /// <typeparamref name="T"/>型戻り値のCleanResultに変換したものを新しく作成します。
        /// Resultは自動でキャストされますが、キャストに失敗した場合CleanResultの状態はFailedになります。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>新しいCleanResult</returns>
        public CleanResult<T> As<T>()
        {
            return new CleanResult<T>(_struct.As<T>());
        }

        /// <inheritdoc cref="CleanResultStruct{TResult}.Box"/>
        public CleanResultBoxed<TResult> Box() => new CleanResultBoxed<TResult>(_struct);

        /// <summary>
        /// 値を専用の struct 型に変換します。
        /// </summary>
        /// <returns>struct化したオブジェクト</returns>
        public CleanResultStruct<TResult> Struct() => _struct;

        /// <inheritdoc/>
        public override string ToString() => _struct.ToString();

        /// <summary>
        /// <see cref="State"/> が <see cref="CleanResultState.Success"/> の時、trueとして扱います。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator true(CleanResult<TResult> t) => t._struct ? true : false;

        /// <summary>
        /// <see cref="State"/> が <see cref="CleanResultState.Success"/> 以外の時、falseとして扱います。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator false(CleanResult<TResult> t) => t._struct ? false : true;

        /// <summary>
        /// <typeparamref name="TResult"/> への暗黙的変換を許可します。ただし、 <see cref="State"/> が <see cref="CleanResultState.Success"/> 以外の時は <see cref="System.InvalidCastException"/> をスローします。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static implicit operator TResult(CleanResult<TResult> t) => t._struct;

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">戻り値</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResult<TResult> Success(TResult result) => new CleanResult<TResult>(CleanResultStruct<TResult>.Success(result));

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">省略可能な戻り値</param>
        /// <param name="error">エラー内容</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResult<TResult> Canceled(TResult result = default, CleanResultError error = null) => new CleanResult<TResult>(CleanResultStruct<TResult>.Canceled(result, error));

        /// <summary>
        /// 操作の失敗を通知する、エラー内容を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="error">エラー内容</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResult<TResult> Failed(CleanResultError error) => new CleanResult<TResult>(CleanResultStruct<TResult>.Failed(error));
    }
}
