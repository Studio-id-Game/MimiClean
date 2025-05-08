using System;
using System.Collections.Generic;
using System.Threading;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="CleanResultErrorList"/>を抽象化します。
    /// </summary>
    public interface ICleanResultErrorList : IEnumerable<CleanResultError>, IReadOnlyCollection<CleanResultError>
    {
        /// <summary>
        /// 現在のエラーリストに対応した<see cref="CleanResultState"/>
        /// </summary>
        CleanResultState LastState { get; }

        /// <summary>
        /// エラーリストにエラーを追加します。
        /// </summary>
        /// <param name="error"></param>
        void AddError(CleanResultError error);

        /// <summary>
        /// 解決したエラーをエラーリストから除外します。
        /// </summary>
        /// <param name="errorCheck">除外条件</param>
        void FixError(Predicate<CleanResultError> errorCheck);

        /// <summary>
        /// ユーザーによるCancel操作を登録します。
        /// </summary>
        /// <param name="cancellationToken"></param>
        void AddCancel(CancellationToken cancellationToken);
    }
}
