using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;

    public class Exit(IExit.IGateway gateway, IExitUseCase usecase, IExit.IPresenter presenter) :
        ControllerVoid(gateway, usecase, presenter), IExit
    {
    }
}
