using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;

    public class MoveItem(IMoveItem.IGateway gateway, IMoveItemUseCase usecase, IMoveItem.IPresenter presenter) :
        Controller<MoveItemInput, MoveItemOutput>(gateway, usecase, presenter), IMoveItem
    {
    }
}
