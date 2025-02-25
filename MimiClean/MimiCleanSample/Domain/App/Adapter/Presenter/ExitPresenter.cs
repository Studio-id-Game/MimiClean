using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Presenter
{
    using IAdapter;

    public class ExitPresenter : PresenterVoid, IExit.IPresenter
    {
        public override CleanResult<CleanResult.Void> Present(in CleanResult<CleanResult.Void> usecaseOutput)
        {
            if (usecaseOutput.IsSuccess)
            {
                Console.WriteLine($"See you again!");
                Environment.Exit(0);
            }

            return usecaseOutput;
        }
    }
}
