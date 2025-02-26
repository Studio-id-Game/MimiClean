using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiCleanSample.Domain.App.IAdapter
{
    using IApp.UseCaseIO;

    public interface IAddItem : IAdapterController<AddItemInput>
    {
        public interface IGateway : IAdapterGateway<AddItemInput>
        {
        }

        public interface IPresenter : IAdapterPresenterVoid
        {
        }
    }
}
