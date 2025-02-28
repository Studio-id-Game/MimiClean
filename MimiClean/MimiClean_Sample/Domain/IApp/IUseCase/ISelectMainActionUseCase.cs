using StudioIdGames.MimiClean.Domain.IApp;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IUseCase
{
    using UseCaseIO;

    /// <summary>
    /// 基本動作リストから動作を選択する全ての動作を抽象化します。
    /// </summary>
    public interface ISelectMainActionUseCase : IAppUseCase<SelectMainActionInput, SelectMainActionOutput>
    {
    }
}
