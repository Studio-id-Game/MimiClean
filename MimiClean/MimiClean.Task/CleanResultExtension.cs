namespace StudioIdGames.MimiClean.Task
{
    using System.Threading.Tasks;

    /// <summary>
    /// <see cref="CleanResult{TResult}"/>と<see cref="Task{T}"/>を組み合わせて利用するためのユーティリティーを拡張メソッドで提供します。
    /// </summary>
    public static class CleanResultTaskExtension
    {
        /// <summary>
        /// <see cref="Task{TResult}"/> を例外なしでエラーをハンドリングできる <see cref="CleanResult{TResult}"/>(TResult=<see cref="Task{TResult}"/>) に変換します。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="state"><see cref="CleanResult{TResult}"/>への変換そのものが有効かどうかを決定します。</param>
        /// <param name="error"><see cref="CleanResult{TResult}"/>への変換そのもののエラー内容を決定します。</param>
        /// <returns></returns>
        public static CleanResult<Task<TResult>> AsCleanResult<TResult>(this Task<TResult> @this, CleanResultState state = CleanResultState.Success, CleanResultError error = null)
        {
            return new CleanResult<Task<TResult>>(state, @this, error);
        }

        /// <summary>
        /// <see cref="Task"/> を例外なしでエラーをハンドリングできる<see cref="CleanResult{TResult}"/>(TResult=<see cref="Task"/>)に変換します。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="state"><see cref="CleanResult{TResult}"/>への変換そのものが有効かどうかを決定します。</param>
        /// <param name="error"><see cref="CleanResult{TResult}"/>への変換そのもののエラー内容を決定します。</param>
        /// <returns></returns>
        public static CleanResult<Task> AsCleanResult(this Task @this, CleanResultState state = CleanResultState.Success, CleanResultError error = null)
        {
            return new CleanResult<Task>(state, @this, error);
        }

        /// <summary>
        ///<see cref="CleanResult{TResult}"/>(TResult=<see cref="Task"/>) を <see cref="CleanResultTaskAwaiter"/> を通して待機可能にします。
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static CleanResultTaskAwaiter GetAwaiter(this CleanResult<Task> @this)
        {
            return new CleanResultTaskAwaiter(@this);
        }

        /// <summary>
        ///<see cref="CleanResult{TResult}"/>(TResult=<typeparamref name="T"/>) を <see cref="CleanResultTaskAwaiter{T}"/> を通して待機可能にします。
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static CleanResultTaskAwaiter<T> GetAwaiter<T>(this CleanResult<Task<T>> @this)
        {
            return new CleanResultTaskAwaiter<T>(@this);
        }
    }
}
