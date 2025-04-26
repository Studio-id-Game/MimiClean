namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IUseCase
{
    using StudioIdGames.MimiClean.IApp;
    using UseCaseIO;

    /// <summary>
    /// 全てのアイテム追加動作を抽象化します。
    /// </summary>
    public interface IAddItemUseCase : IAppUseCase, IAppUseCase<AddItemInput>
    {
    }
}
