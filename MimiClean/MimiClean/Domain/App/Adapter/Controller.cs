namespace StudioIdGames.MimiClean.Domain.App.Adapter
{
    using IAdapter;
    using IApp;

    /// <summary>
    /// 入力、出力、戻り値を持った操作を実装します。
    /// </summary>
    /// <typeparam name="TInput">入力の型</typeparam>
    /// <typeparam name="TOutput">出力の型</typeparam>
    /// <typeparam name="TResult">戻り値の型</typeparam>
    public abstract class Controller<TInput, TOutput, TResult> : IAdapterController<TInput, TOutput, TResult>
    {
        /// <summary>
        /// 入力を実装した <see cref="IAdapterGateway{TInput}"/>
        /// </summary>
        protected IAdapterGateway<TInput> Gateway { get; }

        /// <summary>
        /// 動作を実装した <see cref="IAppUseCase{TInput, TOutput}"/>
        /// </summary>
        protected IAppUseCase<TInput, TOutput> Usecase { get; }

        /// <summary>
        /// 応答を実装した <see cref="IAdapterPresenter{TOutput, TResult}"/>
        /// </summary>
        protected IAdapterPresenter<TOutput, TResult> Presenter { get; }

        /// <summary>
        /// <see cref="Controller{TInput, TOutput, TResult}"/> のコンストラクター
        /// </summary>
        /// <param name="gateway">入力に利用する <see cref="IAdapterGateway{TInput}"/></param>
        /// <param name="usecase">動作に利用する <see cref="IAppUseCase{TInput, TOutput}"/> </param>
        /// <param name="presenter">応答に利用する <see cref="IAdapterPresenter{TOutput, TResult}"/></param>
        protected Controller(IAdapterGateway<TInput> gateway, IAppUseCase<TInput, TOutput> usecase, IAdapterPresenter<TOutput, TResult> presenter)
        {
            Gateway = gateway;
            Usecase = usecase;
            Presenter = presenter;
        }

        /// <inheritdoc/>
        public virtual CleanResult<TResult> Invoke()
        {
            var input = Gateway.MakeInput();
            var output = Usecase.Excute(input);
            var result = Presenter.Present(output);
            return result;
        }

        /// <inheritdoc/>
        CleanResult<object> IAdapterController.Invoke()
        {
            return Invoke().AsObject();
        }
    }

    /// <summary>
    /// 入力と出力を持ち、戻り値を持たない操作を実装します。
    /// </summary>
    /// <typeparam name="TInput">入力の型</typeparam>
    /// <typeparam name="TOutput">出力の型</typeparam>
    public abstract class Controller<TInput, TOutput> : Controller<TInput, TOutput, CleanResult.Void>, IAdapterController<TInput, TOutput>
    {
        /// <summary>
        /// <see cref="Controller{TInput, TOutput}"/> のコンストラクター
        /// </summary>
        /// <param name="gateway">入力に利用する <see cref="IAdapterGateway{TInput}"/></param>
        /// <param name="usecase">動作に利用する <see cref="IAppUseCase{TInput, TOutput}"/> </param>
        /// <param name="presenter">応答に利用する <see cref="IAdapterPresenter{TOutput}"/></param>
        protected Controller(IAdapterGateway<TInput> gateway, IAppUseCase<TInput, TOutput> usecase, IAdapterPresenter<TOutput> presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    /// <summary>
    /// 入力を持ち、出力と戻り値を持たない操作を実装します。
    /// </summary>
    /// <typeparam name="TInput">入力の型</typeparam>
    public abstract class Controller<TInput> : Controller<TInput, CleanResult.Void>, IAdapterController<TInput>
    {
        /// <summary>
        /// <see cref="Controller{TInput}"/> のコンストラクター
        /// </summary>
        /// <param name="gateway">入力に利用する <see cref="IAdapterGateway{TInput}"/></param>
        /// <param name="usecase">動作に利用する <see cref="IAppUseCase{TInput}"/> </param>
        /// <param name="presenter">応答に利用する <see cref="IAdapterPresenterVoid"/></param>
        protected Controller(IAdapterGateway<TInput> gateway, IAppUseCase<TInput> usecase, IAdapterPresenterVoid presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    /// <summary>
    /// 入力も出力も戻り値も持たない操作を実装します。
    /// </summary>
    public abstract class ControllerVoid : Controller<CleanResult.Void>, IAdapterControllerVoid
    {
        /// <summary>
        /// <see cref="ControllerVoid"/> のコンストラクター
        /// </summary>
        /// <param name="gateway">入力に利用する <see cref="IAdapterGatewayVoid"/></param>
        /// <param name="usecase">動作に利用する <see cref="IAppUseCaseVoid"/> </param>
        /// <param name="presenter">応答に利用する <see cref="IAdapterPresenterVoid"/></param>
        protected ControllerVoid(IAdapterGatewayVoid gateway, IAppUseCaseVoid usecase, IAdapterPresenterVoid presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }
}
