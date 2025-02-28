using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    using IApp.UseCaseIO;

    /// <summary>
    /// アイテムを追加する全ての操作を抽象化します。
    /// </summary>
    public interface IAddItem : IAdapterController<AddItemInput>
    {
        /// <summary>
        /// アイテムを追加する際の全ての入力操作を抽象化します。
        /// </summary>
        public interface IGateway : IAdapterGateway<AddItemInput>
        {
        }

        /// <summary>
        /// アイテムを追加する際の全ての出力応答を抽象化します。
        /// </summary>
        public interface IPresenter : IAdapterPresenterVoid
        {
        }
    }
}
