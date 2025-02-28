using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Controller
{
    using DomainType;
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="ISelectMainAction"/>を実装します。
    /// </summary>
    public class SelectMainAction(ISelectMainAction.IGateway gateway, ISelectMainActionUseCase usecase, ISelectMainAction.IPresenter presenter) :
        Controller<SelectMainActionInput, SelectMainActionOutput, MainActions>(gateway, usecase, presenter), ISelectMainAction
    {
    }
}
