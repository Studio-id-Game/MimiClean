using StudioIdGames.MimiClean.Domain.IApp;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IUseCase
{
    using UseCaseIO;

    public interface IAddItemUseCase : IAppUseCase, IAppUseCase<AddItemInput>
    {
    }
}
