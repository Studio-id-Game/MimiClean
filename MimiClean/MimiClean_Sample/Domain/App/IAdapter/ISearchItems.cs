namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    using IApp.UseCaseIO;
    using StudioIdGames.MimiClean.IAdapter;

    /// <summary>
    /// アイテムを検索する全ての操作を抽象化します。
    /// </summary>
    public interface ISearchItems : IAdapterController<SearchItemsInput, SearchItemsOutput>
    {
        /// <summary>
        /// アイテムを検索する際の全ての入力操作を抽象化します。
        /// </summary>
        interface IGateway : IAdapterGateway<SearchItemsInput>
        {
        }

        /// <summary>
        /// アイテムを検索する際の全ての出力応答を抽象化します。
        /// </summary
        interface IPresenter : IAdapterPresenter<SearchItemsOutput>
        {
        }
    }
}
