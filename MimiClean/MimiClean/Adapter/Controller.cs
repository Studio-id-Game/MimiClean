using StudioIdGames.MimiClean.App;

namespace StudioIdGames.MimiClean.Adapter
{
    public abstract class Controller<TInput> : Controller<TInput, CleanResult.Void>, IController
    {
        protected Controller(IGateway<TInput> gateway, Interactor<TInput> usecase, IPresenter presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    public abstract class Controller<TInput, TOutput> : Controller<TInput, TOutput, CleanResult.Void>, IController
    {
        protected Controller(IGateway<TInput> gateway, Interactor<TInput, TOutput> usecase, IPresenter<TOutput> presenter)
            : base(gateway, usecase, presenter)
        {
        }
    }

    public abstract class Controller<TInput, TOutput, TResult> : IController
    {
        protected IGateway<TInput> Gateway { get; }
        protected Interactor<TInput, TOutput> Usecase { get; }
        protected IPresenter<TOutput, TResult> Presenter { get; }

        protected Controller(IGateway<TInput> gateway, Interactor<TInput, TOutput> usecase, IPresenter<TOutput, TResult> presenter)
        {
            Gateway = gateway;
            Usecase = usecase;
            Presenter = presenter;
        }

        public virtual CleanResult<TResult> Invoke()
        {
            var input = Gateway.MakeInput();
            var output = Usecase.Excute(input);
            var result = Presenter.Present(output);
            return result;
        }

        CleanResult<object> IController.Invoke()
        {
            return Invoke().AsObject();
        }
    }
}
