namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IUseCase
{
    using StudioIdGames.MimiClean.IApp;
    using UseCaseIO;

    /// <summary>
    /// 全てのアイテム移動動作を抽象化します。
    /// </summary>
    public interface IMoveItemUseCase : IAppUseCase<MoveItemInput, MoveItemOutput>
    {
    }
}
