namespace StudioIdGames.MimiClean.Domain.App.Adapter
{
    using IAdapter;

    /// <summary>
    /// 出力を持った動作に対する、戻り値を持った応答を実装します。
    /// </summary>
    /// <typeparam name="TOutput">動作の出力の型</typeparam>
    /// <typeparam name="TResult">操作の戻り値の型</typeparam>
    public abstract class Presenter<TOutput, TResult> : IAdapterPresenter<TOutput, TResult>
    {
        public abstract CleanResult<TResult> Present(in CleanResult<TOutput> usecaseOutput);

        public CleanResult<object> Present(in CleanResult<object> usecaseOutput)
        {
            return Present(usecaseOutput.As<TOutput>()).AsObject();
        }
    }

    /// <summary>
    /// 出力を持った動作に対する、戻り値を持たない応答を実装します。
    /// </summary>
    /// <typeparam name="TOutput">動作の出力の型</typeparam>
    public abstract class Presenter<TOutput> : Presenter<TOutput, CleanResult.Void>, IAdapterPresenter<TOutput>
    {
    }

    /// <summary>
    /// 出力を持たない動作に対する、戻り値を持たない応答を実装します。
    /// </summary>
    public abstract class PresenterVoid : Presenter<CleanResult.Void>, IAdapterPresenterVoid
    {
    }
}
