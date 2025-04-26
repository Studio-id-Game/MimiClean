namespace StudioIdGames.MimiClean_Sample.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;
    using StudioIdGames.MimiClean.Adapter;

    /// <summary>
    /// <see cref="IAddItem"/>を実装します。
    /// </summary>
    public class AddItem(IAddItem.IGateway gateway, IAddItemUseCase usecase, IAddItem.IPresenter presenter) :
        Controller<AddItemInput>(gateway, usecase, presenter), IAddItem
    {
    }
}
