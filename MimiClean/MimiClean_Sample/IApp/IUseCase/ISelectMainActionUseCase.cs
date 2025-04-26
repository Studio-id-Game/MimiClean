namespace StudioIdGames.MimiClean_Sample.IApp.IUseCase
{
    using StudioIdGames.MimiClean.IApp;
    using UseCaseIO;

    /// <summary>
    /// 基本動作リストから動作を選択する全ての動作を抽象化します。
    /// </summary>
    public interface ISelectMainActionUseCase : IAppUseCase<SelectMainActionInput, SelectMainActionOutput>
    {
    }
}
