namespace StudioIdGames.MimiClean.Adapter
{
    public interface IPresenter : IPresenter<CleanResult.Void>
    {
    }

    public interface IPresenter<TOutput> : IPresenter<TOutput, CleanResult.Void>
    {
    }

    public interface IPresenter<TOutput, TResult>
    {
        CleanResult<TResult> Present(in CleanResult<TOutput> usecaseOutput);
    }
}
