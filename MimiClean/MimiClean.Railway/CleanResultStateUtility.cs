using System.Collections.Generic;
using System.Linq;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="CleanResultState"/> のユーティリティー関数を提供します。
    /// </summary>
    internal static class CleanResultStateUtility
    {
        /// <summary>
        /// エラーのリストから<see cref="CleanResultState"/>を決定します。
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        internal static CleanResultState FromErrors(IEnumerable<CleanResultError> errors)
        {
            var state = CleanResultState.Success;

            if (errors != null && errors.Any())
            {
                state = CleanResultState.Failed;

                foreach (var error in errors)
                {
                    if (error is CleanResultErrors.CancellationByUserError)
                    {
                        state = CleanResultState.Canceled;
                        break;
                    }
                }
            }

            return state;
        }
    }
}
