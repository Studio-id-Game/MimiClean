namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>をBox化する為のクラス
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class CleanResultBoxed<TResult> : ICleanResult<TResult>
    {
        private readonly CleanResultStruct<TResult> _struct;

        internal CleanResultBoxed(CleanResultStruct<TResult> _struct)
        {
            this._struct = _struct;
        }

        /// <summary>
        /// <see cref="CleanResultBoxed{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResultBoxed(CleanResultState state, TResult result, CleanResultError error)
        {
            _struct = new CleanResultStruct<TResult>(state, result, error);
        }

        /// <summary>
        /// <see cref="CleanResultBoxed{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        public CleanResultBoxed(CleanResultState state, TResult result)
        {
            _struct = new CleanResultStruct<TResult>(state, result);
        }

        /// <summary>
        /// <see cref="CleanResultBoxed{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="state">操作の状態を表します</param>
        /// <param name="error">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResultBoxed(CleanResultState state, CleanResultError error)
        {
            _struct = new CleanResultStruct<TResult>(state, error);
        }

        /// <inheritdoc/>
        public TResult Result => _struct.Result;

        object ICleanResult.Result => _struct.Result;

        /// <inheritdoc/>
        public CleanResultState State => _struct.State;

        /// <inheritdoc/>
        public CleanResultError Error => _struct.Error;

        /// <inheritdoc/>
        public bool IsSuccess => _struct.IsSuccess;

        /// <inheritdoc/>
        public bool IsCanceled => _struct.IsCanceled;

        /// <inheritdoc/>
        public bool IsFailed => _struct.IsFailed;

        /// <inheritdoc/>
        public CleanResultState TryGetValue(out TResult result) => _struct.TryGetValue(out result);

        /// <summary>
        /// 戻り値を捨てたCleanResultを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResultBoxed<CleanResult.Void> AsVoid()
        {
            return new CleanResultBoxed<CleanResult.Void>(_struct.AsVoid());
        }

        /// <summary>
        /// object型戻り値のCleanResultに変換したものを新しく作成します。
        /// </summary>
        /// <returns>新しいCleanResult</returns>
        public CleanResultBoxed<object> AsObject()
        {
            return new CleanResultBoxed<object>(_struct.AsObject());
        }

        /// <summary>
        /// 新しい<typeparamref name="T"/>型戻り値のCleanResultを新しく作成します。
        /// </summary>
        /// <typeparam name="T">新しい型</typeparam>
        /// <param name="result">新しいResult</param>
        /// <returns>新しいCleanResult</returns>
        public CleanResultBoxed<T> As<T>(T result)
        {
            return new CleanResultBoxed<T>(_struct.As(result));
        }

        /// <summary>
        /// <typeparamref name="T"/>型戻り値のCleanResultに変換したものを新しく作成します。
        /// Resultは自動でキャストされますが、キャストに失敗した場合CleanResultの状態はFailedになります。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>新しいCleanResult</returns>
        public CleanResultBoxed<T> As<T>()
        {
            return new CleanResultBoxed<T>(_struct.As<T>());
        }

        /// <inheritdoc cref="CleanResultStruct{TResult}.Ref"/>
        public CleanResult<TResult> Unbox() => new CleanResult<TResult>(_struct);

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
        public static bool operator true(CleanResultBoxed<TResult> t) => t._struct ? true : false;

        /// <summary>
        /// <see cref="State"/> が <see cref="CleanResultState.Success"/> 以外の時、falseとして扱います。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator false(CleanResultBoxed<TResult> t) => t._struct ? false : true;

        /// <summary>
        /// <typeparamref name="TResult"/> への暗黙的変換を許可します。ただし、 <see cref="State"/> が <see cref="CleanResultState.Success"/> 以外の時は <see cref="System.InvalidCastException"/> をスローします。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static implicit operator TResult(CleanResultBoxed<TResult> t) => t._struct;

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">戻り値</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResultBoxed<TResult> Success(TResult result)
        {
            return new CleanResultBoxed<TResult>(CleanResultStruct<TResult>.Success(result));
        }

        /// <summary>
        /// 操作の成功を通知する、戻り値を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="result">省略可能な戻り値</param>
        /// <param name="error">エラー内容</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResultBoxed<TResult> Canceled(TResult result = default, CleanResultError error = null)
        {
            return new CleanResultBoxed<TResult>(CleanResultStruct<TResult>.Canceled(result, error));
        }

        /// <summary>
        /// 操作の失敗を通知する、エラー内容を持ったオブジェクトを返します。
        /// </summary>
        /// <param name="error">エラー内容</param>
        /// <returns>作成したCleanResultオブジェクト</returns>
        public static CleanResultBoxed<TResult> Failed(CleanResultError error)
        {
            return new CleanResultBoxed<TResult>(CleanResultStruct<TResult>.Failed(error));
        }
    }
}
