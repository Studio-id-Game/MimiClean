namespace StudioIdGames.MimiClean.Domain.App.Adapter
{
    using IAdapter;
    using IApp;

    /// <summary>
    /// <see cref="IAdapterGateway{TInput}"/>, <see cref="IAppUseCase{TInput, TOutput}"/>, <see cref="IAdapterPresenter{TOutput, TResult}"/> を接続し、
    /// 環境層での操作を実現する為の抽象クラスです。
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class Controller<TInput, TOutput, TResult> : IAdapterController<TInput, TOutput, TResult>
    {
        /// <summary>
        /// 入力に利用する <see cref="IAdapterGateway{TInput}"/>
        /// </summary>
        protected IAdapterGateway<TInput> Gateway { get; }

        /// <summary>
        /// 動作に利用する <see cref="IAppUseCase{TInput, TOutput}"/>
        /// </summary>
        protected IAppUseCase<TInput, TOutput> Usecase { get; }

        /// <summary>
        /// 応答に利用する <see cref="IAdapterPresenter{TOutput, TResult}"/>
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

        /// <inheritdoc cref="IAdapterController.Invoke"/>
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

    /// <inheritdoc/>
    public abstract class Controller<TInput, TOutput> : Controller<TInput, TOutput, CleanResult.Void>, IAdapterController<TInput, TOutput>
    {
        protected Controller(IAdapterGateway<TInput> gateway, IAppUseCase<TInput, TOutput> usecase, IAdapterPresenter<TOutput> presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    /// <inheritdoc/>
    public abstract class Controller<TInput> : Controller<TInput, CleanResult.Void>, IAdapterController<TInput>
    {
        protected Controller(IAdapterGateway<TInput> gateway, IAppUseCase<TInput> usecase, IAdapterPresenterVoid presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    /// <inheritdoc/>
    public abstract class ControllerVoid : Controller<CleanResult.Void>, IAdapterControllerVoid
    {
        protected ControllerVoid(IAdapterGatewayVoid gateway, IAppUseCaseVoid usecase, IAdapterPresenterVoid presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }
}
