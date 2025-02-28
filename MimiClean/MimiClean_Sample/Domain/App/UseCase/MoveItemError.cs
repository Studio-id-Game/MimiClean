using StudioIdGames.MimiClean.Domain.App;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using IApp.IUseCase;

    /// <summary>
    /// アイテムを移動する動作のエラー
    /// </summary>
    /// <param name="usecase">エラーが発生した動作</param>
    /// <param name="errorCase">エラーの内容</param>
    public sealed class MoveItemError(IMoveItemUseCase usecase, in MoveItemErrorCase errorCase) : UseCaseError<MoveItemErrorCase>(usecase, errorCase)
    {
    }
}
