using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    using IApp.UseCaseIO;

    /// <summary>
    /// アイテムを移動する全ての操作を抽象化します。
    /// </summary>
    public interface IMoveItem : IAdapterController<MoveItemInput, MoveItemOutput>
    {
        /// <summary>
        /// アイテムを移動する際の全ての入力操作を抽象化します。
        /// </summary>
        public interface IGateway : IAdapterGateway<MoveItemInput>
        {
        }

        /// <summary>
        /// アイテムを移動する際の全ての出力応答を抽象化します。
        /// </summary
        public interface IPresenter : IAdapterPresenter<MoveItemOutput>
        {
        }
    }
}
