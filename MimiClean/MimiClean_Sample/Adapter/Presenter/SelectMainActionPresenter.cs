namespace StudioIdGames.MimiClean_Sample.Adapter.Presenter
{
    using IAdapter;
    using IApp.UseCaseIO;
    using StudioIdGames.MimiClean.Adapter;
    using StudioIdGames.MimiClean.Railway;
    using StudioIdGames.MimiClean_Sample.Domain.DomainType;

    /// <summary>
    /// <see cref="ISelectMainAction.IPresenter"/> を実装します。
    /// </summary>
    public class SelectMainActionPresenter : Presenter<SelectMainActionOutput, MainActions>, ISelectMainAction.IPresenter
    {
        public override CleanResult<MainActions> Present(in CleanResult<SelectMainActionOutput> usecaseOutput)
        {
            switch (usecaseOutput.TryGetValue(out var output))
            {
                case CleanResultState.Success:
                    Console.WriteLine($"{output.mainAction} action is Success.");
                    break;

                case CleanResultState.Canceled:
                    Console.WriteLine($"{output.mainAction} action is Canceled.");
                    break;

                case CleanResultState.Failed:
                    Console.WriteLine($"{output.mainAction} action is Failed. `{usecaseOutput.Error}`");
                    break;
            }

            return usecaseOutput.As(output.mainAction);
        }
    }
}
