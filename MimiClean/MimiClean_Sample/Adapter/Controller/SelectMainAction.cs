namespace StudioIdGames.MimiClean_Sample.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;
    using StudioIdGames.MimiClean.Adapter;
    using StudioIdGames.MimiClean_Sample.Domain.DomainType;

    /// <summary>
    /// <see cref="ISelectMainAction"/>を実装します。
    /// </summary>
    public class SelectMainAction(ISelectMainAction.IGateway gateway, ISelectMainActionUseCase usecase, ISelectMainAction.IPresenter presenter) :
        Controller<SelectMainActionInput, SelectMainActionOutput, MainActions>(gateway, usecase, presenter), ISelectMainAction
    {
    }
}
