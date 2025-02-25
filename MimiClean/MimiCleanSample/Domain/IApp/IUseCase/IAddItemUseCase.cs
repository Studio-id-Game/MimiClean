using StudioIdGames.MimiClean.Domain.IApp;

namespace StudioIdGames.MimiCleanSample.Domain.IApp.IUseCase
{
    using UseCaseIO;
    public interface IAddItemUseCase : IAppUseCase, IAppUseCase<AddItemInput>
    {
    }
}
