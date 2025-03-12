using System;

namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// <see cref="System.Exception"/>を内包する、<see cref="CleanResultError"/>
    /// </summary>
    public class CleanResultException : CleanResultError
    {
        /// <summary>
        /// 内包する <see cref="System.Exception"/>
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="exception">内包する <see cref="System.Exception"/></param>
        public CleanResultException(Exception exception)
        {
            Exception = exception;
        }

        /// <inheritdoc/>
        public override string Message => Exception.Message;

        /// <summary>
        /// <see cref="System.Exception"/>からの暗黙的変換を許可します。
        /// </summary>
        /// <param name="exception"></param>
        public static implicit operator CleanResultException(Exception exception)
        {
            return new CleanResultException(exception);
        }
    }
}
