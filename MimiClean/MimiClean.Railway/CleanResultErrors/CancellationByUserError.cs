using System.Threading;

namespace StudioIdGames.MimiClean.Railway.CleanResultErrors
{
    /// <summary>
    /// ユーザーによる操作の中断を表すエラー
    /// </summary>
    public sealed class CancellationByUserError : CleanResultError
    {
        /// <inheritdoc/>
        public override string Message => "This operation is Canceled by user.";

        /// <summary>
        /// 存在する場合、この操作に対する<see cref="System.Threading.CancellationToken"/>
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// 存在する場合、この操作に対する<see cref="System.Threading.CancellationToken"/> を指定してエラーを作成します。
        /// </summary>
        /// <param name="cancellationToken"></param>
        public CancellationByUserError(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }
    }
}
