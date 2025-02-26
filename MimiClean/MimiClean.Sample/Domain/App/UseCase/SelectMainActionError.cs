using StudioIdGames.MimiClean.Domain.App;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using DomainType;
    using IApp.IUseCase;

    public class SelectMainActionError(ISelectMainActionUseCase useCase, MainActions action) : UseCaseError<MainActions>(useCase, action)
    {
        protected override string ErrorCaseMessage(MainActions caseInfo)
        {
            return caseInfo switch
            {
                MainActions.None or
                MainActions.AddItem or
                MainActions.MoveItem or
                MainActions.SearchItems or
                MainActions.Exit => base.ErrorCaseMessage(caseInfo),
                _ => base.DefaultErrorMessage("UnknownAction"),
            };
        }
    }
}
