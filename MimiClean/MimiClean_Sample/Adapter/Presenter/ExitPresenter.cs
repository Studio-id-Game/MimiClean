namespace StudioIdGames.MimiClean_Sample.Adapter.Presenter
{
    using IAdapter;
    using StudioIdGames.MimiClean.Adapter;
    using StudioIdGames.MimiClean.Railway;

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
