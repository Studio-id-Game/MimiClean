using System;

namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>のためのエラーを表現するクラス
    /// </summary>
    public abstract class CleanResultError
    {
        /// <summary>
        /// エラーの内容を表す文字列
        /// </summary>
        public abstract string Message { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Message;
        }

        public static implicit operator CleanResultError(Exception exception)
        {
            return new CleanResultException(exception);
        }
    }
}
