using System;
using System.Collections.Generic;
using System.Threading;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// 戻り値の無い <see cref="CleanResult{TResult}"/> の拡張メソッドとFactoryメソッドを提供します。
    /// </summary>
    public static class FromVoid
    {
        /// <summary>
        /// <see cref="CancellationToken"/>を戻り値オブジェクトに変換します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<NoResult> ToVoidResult(this CancellationToken cancellationToken) => NoResult.Canceled(cancellationToken);

        /// <summary>
        /// <see cref="IEnumerable{CleanResultError}"/>を戻り値オブジェクトに変換します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<NoResult> ToVoidResult(this IEnumerable<CleanResultError> errors) => NoResult.Failed(errors);

        /// <summary>
        /// <see cref="CleanResultState"/>を戻り値オブジェクトに変換します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<NoResult> ToVoidResult(this CleanResultState state, CancellationToken cancellationToken = default, IEnumerable<CleanResultError> errors = null)
        {
            switch (state)
            {
                case CleanResultState.Success:
                    return NoResult.Success();

                case CleanResultState.Canceled:
                    return NoResult.Canceled(cancellationToken);

                case CleanResultState.Failed:
                    return NoResult.Failed(errors);

                default:
                    throw new NotSupportedException(state.ToString());
            }
        }
    }
}
