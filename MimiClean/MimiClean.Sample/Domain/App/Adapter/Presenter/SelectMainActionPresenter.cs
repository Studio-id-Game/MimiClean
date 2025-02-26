using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Presenter
{
    using DomainType;
    using IAdapter;
    using IApp.UseCaseIO;

    internal class SelectMainActionPresenter : Presenter<SelectMainActionOutput, MainActions>, ISelectMainAction.IPresenter
    {
        public override CleanResult<MainActions> Present(in CleanResult<SelectMainActionOutput> usecaseOutput)
        {
            var act = usecaseOutput.Result.mainAction;

            switch (usecaseOutput.State)
            {
                case CleanResultState.Success:
                    Console.WriteLine($"{act} action is Success.");
                    break;

                case CleanResultState.Canceled:
                    Console.WriteLine($"{act} action is Canceled.");
                    break;

                case CleanResultState.Failed:
                    Console.WriteLine($"{act} action is Failed. `{usecaseOutput.Error}`");
                    break;
            }

            return usecaseOutput.As(act);
        }
    }
}
