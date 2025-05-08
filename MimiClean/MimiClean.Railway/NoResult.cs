using System.Collections.Generic;
using System.Threading;
using System;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// 戻り値の無い型を表現するためのダミー構造体
    /// </summary>
    public readonly struct NoResult
    {
        /// <summary>
        /// 操作の成功を通知する、戻り値の無いオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<NoResult> Success() => new CleanResult<NoResult>(default);

        /// <summary>
        /// 操作の中断を通知する、戻り値の無いオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<NoResult> Canceled(CancellationToken cancellationToken) => new CleanResult<NoResult>(default, cancellationToken);

        /// <summary>
        /// 操作の失敗を通知する、戻り値の無いオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<NoResult> Failed(IEnumerable<CleanResultError> errors) => new CleanResult<NoResult>(default, errors);

        /// <summary>
        /// 操作の終了を通知する、戻り値の無いオブジェクトを返します。
        /// </summary>
        /// <returns></returns>
        public static CleanResult<NoResult> State(CleanResultState state, CancellationToken cancellationToken = default, IEnumerable<CleanResultError> errors = null)
        {
            switch (state)
            {
                case CleanResultState.Success:
                    return Success();

                case CleanResultState.Canceled:
                    return errors.ToVoidResult();

                case CleanResultState.Failed:
                    return cancellationToken.ToVoidResult();

                default:
                    throw new NotSupportedException(state.ToString());
            }
        }
    }
}
