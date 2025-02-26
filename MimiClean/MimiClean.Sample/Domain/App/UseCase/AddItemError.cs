using StudioIdGames.MimiClean.Domain.App;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using IApp.IUseCase;

    public sealed class AddItemError(IAddItemUseCase useCase, AddItemErrorCase errorCase) :
        UseCaseError<AddItemErrorCase>(useCase, errorCase)
    {
    }
}
