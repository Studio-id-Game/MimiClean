using StudioIdGames.MimiClean.Railway.CleanResultErrors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>の破棄する必要があるリソース。エラーリストへのアクセスを含みます。
    /// </summary>
    public readonly struct CleanResultErrorClose : IDisposable, IEnumerable<CleanResultError>, IReadOnlyCollection<CleanResultError>
    {
        private readonly CleanResultErrorToken errorToken;

        internal CleanResultErrorClose(CleanResultErrorToken errorToken)
        {
            this.errorToken = errorToken;
        }

        /// <summary>
        /// エラーリスト
        /// </summary>
        public IEnumerable<CleanResultError> Errors => errorToken.GetEnumerable();

        /// <inheritdoc/>
        public int Count => errorToken.Count;

        /// <inheritdoc/>
        public void Dispose()
        {
            if (errorToken.LastState == CleanResultState.Failed)
            {
                var message =
                    $"{errorToken.Count}個のエラーが未解決のままCleanResultが解放されました。" +
                    $"CleanResultを解放する際は、CleanResult.Chain()関数等を利用して{nameof(CancellationByUserError)}以外の全てのエラーを処理して解決済にする必要があります。\n{string.Join("\n", Errors)}";
                throw new InvalidOperationException(message);
            }
            else
            {
                errorToken.Dispose();
            }
        }

        /// <inheritdoc/>
        public IEnumerator<CleanResultError> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Errors.GetEnumerator();
        }
    }
}
