using StudioIdGames.MimiClean.Adapter;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.App.UseCase;
using static StudioIdGames.MimiCleanSample.Adapter.Gateway.ItemGateways;
using static StudioIdGames.MimiCleanSample.Adapter.Presenter.ItemPresenters;

namespace StudioIdGames.MimiCleanSample.Adapter.Controller
{
    internal static class ItemController
    {
        public class AddItemController(IGateway<AddItemInput> gateway, Interactor<AddItemInput> usecase, IPresenter presenter) :
            Controller<AddItemInput>(gateway, usecase, presenter)
        {
            public static AddItemController Default => new(new AddItemGateway(), new AddItem(), new AddItemPresenter());
            public static AddItemController Dummy => new(new AddItemGatewayDummy(), new AddItem(), new AddItemPresenter());
        }

        public class MoveItemController(IGateway<MoveItemInput> gateway, Interactor<MoveItemInput, MoveItemOutput> usecase, IPresenter<MoveItemOutput> presenter) :
            Controller<MoveItemInput, MoveItemOutput>(gateway, usecase, presenter)
        {
            public static MoveItemController Default => new(new MoveItemGateway(), new MoveItem(), new MoveItemPresenter());
            public static MoveItemController Dummy => new(new MoveItemGatewayDummy(), new MoveItem(), new MoveItemPresenter());
        }

        public class SearchItemsController(IGateway<SearchItemsInput> gateway, Interactor<SearchItemsInput, SearchItemsOutput> usecase, IPresenter<SearchItemsOutput> presenter) :
            Controller<SearchItemsInput, SearchItemsOutput>(gateway, usecase, presenter)
        {
            public static SearchItemsController Default => new(new SearchItemsGateway(), new SearchItems(), new SearchItemsPresenter());
            public static SearchItemsController Dummy => new(new SearchItemsGatewayDummy(), new SearchItems(), new SearchItemsPresenter());
        }
    }
}
