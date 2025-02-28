using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Presenter
{
    using IAdapter;

    /// <summary>
    /// <see cref="IExit.IPresenter"/> を実装します。
    /// </summary>
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
