using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    using DomainType;
    using IApp.UseCaseIO;

    public interface ISelectMainAction : IAdapterController<SelectMainActionInput, SelectMainActionOutput, MainActions>
    {
        public interface IGateway : IAdapterGateway<SelectMainActionInput>
        {
        }

        public interface IPresenter : IAdapterPresenter<SelectMainActionOutput, MainActions>
        {
        }
    }
}
