using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;

    /// <summary>
    /// <see cref="IExit"/>を実装します。
    /// </summary>
    public class Exit(IExit.IGateway gateway, IExitUseCase usecase, IExit.IPresenter presenter) :
        ControllerVoid(gateway, usecase, presenter), IExit
    {
    }
}
