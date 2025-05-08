using System.Threading;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// 任意の型のオブジェクトを値とした <see cref="CleanResult{TResult}"/> の拡張メソッドとFactoryメソッドを提供します。
    /// </summary>
    public static class FromValue
    {
        /// <summary>
        /// 操作の成功を通知する、戻り値のあるオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<T> ToCleanResult<T>(this T value) => new CleanResult<T>(value);

        /// <summary>
        /// 操作の中断を通知する、戻り値のあるオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<T> ToCleanResult<T>(this T value, CancellationToken cancellationToken) => new CleanResult<T>(value, cancellationToken);

        /// <summary>
        /// 操作の失敗を通知する、戻り値のあるオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<T> ToCleanResult<T>(this T value, params CleanResultError[] error) => new CleanResult<T>(value, error);
    }
}
