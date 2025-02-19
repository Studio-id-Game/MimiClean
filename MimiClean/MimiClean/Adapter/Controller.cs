using StudioIdGames.MimiClean.App;

namespace StudioIdGames.MimiClean.Adapter
{
    /// <inheritdoc/>
    public abstract class Controller<TInput> : Controller<TInput, CleanResult.Void>, IController
    {
        protected Controller(IGateway<TInput> gateway, IUseCase<TInput> usecase, IPresenter presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    /// <inheritdoc/>
    public abstract class Controller<TInput, TOutput> : Controller<TInput, TOutput, CleanResult.Void>, IController
    {
        protected Controller(IGateway<TInput> gateway, IUseCase<TInput, TOutput> usecase, IPresenter<TOutput> presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    /// <summary>
    /// <see cref="IGateway{TInput}"/>, <see cref="IUseCase{TInput, TOutput}"/>, <see cref="IPresenter{TOutput, TResult}"/> を接続し、
    /// 環境層での操作を実現する為の抽象クラスです。
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class Controller<TInput, TOutput, TResult> : IController
    {
        /// <summary>
        /// 入力に利用する <see cref="IGateway{TInput}"/>
        /// </summary>
        protected IGateway<TInput> Gateway { get; }

        /// <summary>
        /// 動作に利用する <see cref="IUseCase{TInput, TOutput}"/> 
        /// </summary>
        protected IUseCase<TInput, TOutput> Usecase { get; }

        /// <summary>
        /// 応答に利用する <see cref="IPresenter{TOutput, TResult}"/>
        /// </summary>
        protected IPresenter<TOutput, TResult> Presenter { get; }

        /// <summary>
        /// <see cref="Controller{TInput, TOutput, TResult}"/> のコンストラクター
        /// </summary>
        /// <param name="gateway">入力に利用する <see cref="IGateway{TInput}"/></param>
        /// <param name="usecase">動作に利用する <see cref="IUseCase{TInput, TOutput}"/> </param>
        /// <param name="presenter">応答に利用する <see cref="IPresenter{TOutput, TResult}"/></param>
        protected Controller(IGateway<TInput> gateway, IUseCase<TInput, TOutput> usecase, IPresenter<TOutput, TResult> presenter)
        {
            Gateway = gateway;
            Usecase = usecase;
            Presenter = presenter;
        }

        /// <inheritdoc cref="IController.Invoke"/>
        public virtual CleanResult<TResult> Invoke()
        {
            var input = Gateway.MakeInput();
            var output = Usecase.Excute(input);
            var result = Presenter.Present(output);
            return result;
        }

        /// <inheritdoc/>
        CleanResult<object> IController.Invoke()
        {
            return Invoke().AsObject();
        }
    }
}
