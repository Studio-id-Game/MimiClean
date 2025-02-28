using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    /// <summary>
    /// プログラムを終了する全ての操作を抽象化します。
    /// </summary>
    public interface IExit : IAdapterControllerVoid
    {
        /// <summary>
        /// プログラムを終了する際の全ての入力操作を抽象化します。
        /// </summary>
        public interface IGateway : IAdapterGatewayVoid
        {
        }

        /// <summary>
        /// プログラムを終了する際の全ての出力応答を抽象化します。
        /// </summary>
        public interface IPresenter : IAdapterPresenterVoid
        {
        }
    }
}
