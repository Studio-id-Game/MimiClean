using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using DomainType;
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="ISelectMainActionUseCase"/> の実装
    /// </summary>
    /// <param name="serviceProvider"></param>
    public class SelectMainActionUseCase(MimiServiceProvider serviceProvider) : Usecase<SelectMainActionInput, SelectMainActionOutput>, ISelectMainActionUseCase
    {
        public override CleanResult<SelectMainActionOutput> Excute(in CleanResult<SelectMainActionInput> input)
        {
            var mainAction = input.Result.mainAction;
            if (!input.IsSuccess)
            {
                return input.As(new SelectMainActionOutput(mainAction));
            }

            var res = mainAction switch
            {
                MainActions.AddItem => serviceProvider.GetService<IAddItem>().Invoke(),
                MainActions.MoveItem => serviceProvider.GetService<IMoveItem>().Invoke(),
                MainActions.SearchItems => serviceProvider.GetService<ISearchItems>().Invoke(),
                MainActions.Exit => serviceProvider.GetService<IExit>().Invoke(),
                _ => CleanResult.Failed(new SelectMainActionError(this, mainAction)),
            };
            return res.As(new SelectMainActionOutput(mainAction));
        }
    }
}
