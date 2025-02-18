using StudioIdGames.MimiClean.Adapter;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.Adapter.Gateway;
using StudioIdGames.MimiCleanSample.Adapter.Presenter;
using StudioIdGames.MimiCleanSample.App.UseCase;
using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample.Adapter.Controller
{
    internal class SelectMainActionController(IGateway<SelectMainActionInput> gateway, Interactor<SelectMainActionInput, MainActions> usecase, IPresenter<MainActions, MainActions> presenter) :
        Controller<SelectMainActionInput, MainActions, MainActions>(gateway, usecase, presenter)
    {
        public static SelectMainActionController Default => new(new SelectMainActionGateway(false), new SelectMainAction(), new SelectMainActionPresenter());
        public static SelectMainActionController Dummy => new(new SelectMainActionGateway(true), new SelectMainAction(), new SelectMainActionPresenter());
    }
}
