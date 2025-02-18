using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiCleanSample.App.Service;
using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal class SelectMainAction : Interactor<SelectMainActionInput, MainActions>
    {
        public override CleanResult<MainActions> Excute(in CleanResult<SelectMainActionInput> input)
        {
            var mainAction = input.Result.mainAction;
            var useDummy = input.Result.useDummy;

            if (!input.IsSuccess)
            {
                return input.As(mainAction);
            }

            var service = Service<IMainActionService>.I;
            var res = service.Invoke(mainAction, useDummy);

            return res.As(mainAction);
        }
    }
}
