using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiCleanSample.Domain.App.IAdapter
{
    using IApp.UseCaseIO;

    public interface IMoveItem : IAdapterController<MoveItemInput, MoveItemOutput>
    {
        public interface IGateway : IAdapterGateway<MoveItemInput>
        {
        }

        public interface IPresenter : IAdapterPresenter<MoveItemOutput>
        {
        }
    }
}
