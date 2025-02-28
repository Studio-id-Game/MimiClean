using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    using DomainType;
    using IApp.UseCaseIO;

    /// <summary>
    /// 基本動作を選択する全ての操作を抽象化します。
    /// </summary>
    public interface ISelectMainAction : IAdapterController<SelectMainActionInput, SelectMainActionOutput, MainActions>
    {
        /// <summary>
        /// 基本動作を選択する際の全ての入力操作を抽象化します。
        /// </summary>
        public interface IGateway : IAdapterGateway<SelectMainActionInput>
        {
        }

        /// <summary>
        /// 基本動作を選択する際の全ての出力応答を抽象化します。
        /// </summary
        public interface IPresenter : IAdapterPresenter<SelectMainActionOutput, MainActions>
        {
        }
    }
}
