namespace StudioIdGames.MimiClean_Sample.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;
    using StudioIdGames.MimiClean.Adapter;

    /// <summary>
    /// <see cref="IExit"/>を実装します。
    /// </summary>
    public class Exit(IExit.IGateway gateway, IExitUseCase usecase, IExit.IPresenter presenter) :
        ControllerVoid(gateway, usecase, presenter), IExit
    {
    }
}
