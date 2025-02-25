using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanSample.Domain.App
{
    using IApp.IUseCase;
    using UseCase;

    public static class AppSetup
    {
        public static void SetDefaultService<TInt2D>(MimiServiceContainer container)
        {
            DomainSetup.SetDefaultService<TInt2D>(container);

            MimiServiceDefault<IAddItemUseCase>.Set<AddItemUseCase<TInt2D>>(container, 0);
            MimiServiceDefault<IExitUseCase>.Set<ExitUseCase>(container, 0);
            MimiServiceDefault<IMoveItemUseCase>.Set<MoveItemUseCase<TInt2D>>(container, 0);
            MimiServiceDefault<ISearchItemsUseCase>.Set<SearchItemsUsecase<TInt2D>>(container, 0);
            MimiServiceDefault<ISelectMainActionUseCase>.Set<SelectMainActionUseCase>(container, 0);
        }
    }
}
