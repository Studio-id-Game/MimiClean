using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Controller
{
    using DomainType;
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;

    public class SelectMainAction(ISelectMainAction.IGateway gateway, ISelectMainActionUseCase usecase, ISelectMainAction.IPresenter presenter) :
        Controller<SelectMainActionInput, SelectMainActionOutput, MainActions>(gateway, usecase, presenter), ISelectMainAction
    {
    }
}
