using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;

    public class AddItem(IAddItem.IGateway gateway, IAddItemUseCase usecase, IAddItem.IPresenter presenter) :
        Controller<AddItemInput>(gateway, usecase, presenter), IAddItem
    {
    }
}
