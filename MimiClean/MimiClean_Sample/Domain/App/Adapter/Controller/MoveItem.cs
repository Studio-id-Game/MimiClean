namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;
    using StudioIdGames.MimiClean.Adapter;

    /// <summary>
    /// <see cref="IMoveItem"/>を実装します。
    /// </summary>
    public class MoveItem(IMoveItem.IGateway gateway, IMoveItemUseCase usecase, IMoveItem.IPresenter presenter) :
        Controller<MoveItemInput, MoveItemOutput>(gateway, usecase, presenter), IMoveItem
    {
    }
}
