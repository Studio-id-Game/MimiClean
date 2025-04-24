using Assets.StudioIdGames.MimiCleanUnity.Runtime.CleanResultUniTask;
using Cysharp.Threading.Tasks;
using StudioIdGames.MimiClean;

namespace Assets.StudioIdGames.MimiCleanUnity.Runtime.CleanResultUniTask
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>と<see cref="UniTask{T}"/>を組み合わせて利用するためのユーティリティーを拡張メソッドで提供します。
    /// </summary>
    public static class CleanResultUniTaskExtension
    {
        /// <summary>
        /// <see cref="UniTask{TResult}"/> を例外なしでエラーをハンドリングできる <see cref="CleanResult{TResult}"/>(TResult=<see cref="UniTask{TResult}"/>) に変換します。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="state"><see cref="CleanResult{TResult}"/>への変換そのものが有効かどうかを決定します。</param>
        /// <param name="error"><see cref="CleanResult{TResult}"/>への変換そのもののエラー内容を決定します。</param>
        /// <returns></returns>
        public static CleanResult<UniTask<TResult>> AsCleanResult<TResult>(this UniTask<TResult> @this, CleanResultState state = CleanResultState.Success, CleanResultError error = null)
        {
            return new CleanResult<UniTask<TResult>>(state, @this, error);
        }

        /// <summary>
        /// <see cref="UniTask"/> を例外なしでエラーをハンドリングできる<see cref="CleanResult{TResult}"/>(TResult=<see cref="UniTask"/>)に変換します。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="state"><see cref="CleanResult{TResult}"/>への変換そのものが有効かどうかを決定します。</param>
        /// <param name="error"><see cref="CleanResult{TResult}"/>への変換そのもののエラー内容を決定します。</param>
        /// <returns></returns>
        public static CleanResult<UniTask> AsCleanResult(this UniTask @this, CleanResultState state = CleanResultState.Success, CleanResultError error = null)
        {
            return new CleanResult<UniTask>(state, @this, error);
        }

        /// <summary>
        ///<see cref="CleanResult{TResult}"/>(TResult=<see cref="UniTask"/>) を <see cref="CleanResultUniTaskAwaiter"/> を通して待機可能にします。
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static CleanResultUniTaskAwaiter GetAwaiter(this CleanResult<UniTask> @this)
        {
            return new CleanResultUniTaskAwaiter(@this);
        }

        /// <summary>
        ///<see cref="CleanResult{TResult}"/>(TResult=<see cref="UniTask{T}"/>) を <see cref="CleanResultUniTaskAwaiter{T}"/> を通して待機可能にします。
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static CleanResultUniTaskAwaiter<T> GetAwaiter<T>(this CleanResult<UniTask<T>> @this)
        {
            return new CleanResultUniTaskAwaiter<T>(@this);
        }
    }
}
