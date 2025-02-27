using System;

namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// <see cref="CleanResult{TResult}.Result"/>を他の型に変換しようとして失敗した場合のエラーを表します
    /// </summary>
    /// <typeparam name="T">変換先の型</typeparam>
    public class CleanResultCastError : CleanResultError
    {
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
