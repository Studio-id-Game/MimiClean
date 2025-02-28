using StudioIdGames.MimiClean.Domain.App;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using IApp.IUseCase;

    /// <summary>
    /// アイテムを追加する動作のエラー
    /// </summary>
    /// <param name="useCase">エラーが発生した動作</param>
    /// <param name="errorCase">エラーの内容</param>
    public sealed class AddItemError(IAddItemUseCase useCase, AddItemErrorCase errorCase) :
        UseCaseError<AddItemErrorCase>(useCase, errorCase)
    {
    }
}
