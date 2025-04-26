namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IUseCase
{
    using StudioIdGames.MimiClean.IApp;
    using UseCaseIO;

    /// <summary>
    /// 全てのアイテム検索動作を抽象化します。
    /// </summary>
    public interface ISearchItemsUseCase : IAppUseCase<SearchItemsInput, SearchItemsOutput>
    {
    }
}
