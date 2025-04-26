namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    using IApp.UseCaseIO;
    using StudioIdGames.MimiClean.IAdapter;

    /// <summary>
    /// アイテムを移動する全ての操作を抽象化します。
    /// </summary>
    public interface IMoveItem : IAdapterController<MoveItemInput, MoveItemOutput>
    {
        /// <summary>
        /// アイテムを移動する際の全ての入力操作を抽象化します。
        /// </summary>
        interface IGateway : IAdapterGateway<MoveItemInput>
        {
        }

        /// <summary>
        /// アイテムを移動する際の全ての出力応答を抽象化します。
        /// </summary
        interface IPresenter : IAdapterPresenter<MoveItemOutput>
        {
        }
    }
}
