using StudioIdGames.MimiClean.Domain.IApp;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IUseCase
{
    using UseCaseIO;

    /// <summary>
    /// 全てのアイテム検索動作を抽象化します。
    /// </summary>
    public interface ISearchItemsUseCase : IAppUseCase<SearchItemsInput, SearchItemsOutput>
    {
    }
}
