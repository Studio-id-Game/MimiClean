namespace StudioIdGames.MimiClean
{
    using System;

    /// <summary>
    /// <see cref="CleanResult{TResult}.Result"/>を他の型に変換しようとして失敗した場合のエラーを表します
    /// </summary>
    public class CleanResultCastError : CleanResultError
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="tResult">変換元の型</param>
        /// <param name="t">変換先の型</param>
        public CleanResultCastError(Type tResult, Type t)
        {
            TResult = tResult;
            T = t;
        }

        /// <summary>
        /// 変換元の型
        /// </summary>
        public Type TResult { get; }

        /// <summary>
        /// 変換先の型
        /// </summary>
        public Type T { get; }

        /// <inheritdoc/>
        public override string Message => $"Can't cast {TResult.Name} to {T.Name}";
    }
}
