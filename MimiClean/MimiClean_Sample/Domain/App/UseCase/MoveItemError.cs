using StudioIdGames.MimiClean.Domain.App;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using IApp.IUseCase;

    public sealed class MoveItemError(IMoveItemUseCase usecase, in MoveItemErrorCase errorCase) : UseCaseError<MoveItemErrorCase>(usecase, errorCase)
    {
    }
}
