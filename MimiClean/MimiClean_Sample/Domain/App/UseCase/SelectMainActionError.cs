using StudioIdGames.MimiClean.Domain.App;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using DomainType;
    using IApp.IUseCase;

    /// <summary>
    /// 基本動作リストから動作を選択する動作のエラー
    /// </summary>
    /// <param name="useCase">エラーが発生した動作</param>
    /// <param name="action">エラー原因の選択肢</param>
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
