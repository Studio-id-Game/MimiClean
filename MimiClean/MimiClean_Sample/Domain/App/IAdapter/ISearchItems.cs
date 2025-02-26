using StudioIdGames.MimiClean.Domain.App.IAdapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.IAdapter
{
    using IApp.UseCaseIO;

    public interface ISearchItems : IAdapterController<SearchItemsInput, SearchItemsOutput>
    {
        public interface IGateway : IAdapterGateway<SearchItemsInput>
        {
        }

        public interface IPresenter : IAdapterPresenter<SearchItemsOutput>
        {
        }
    }
}
