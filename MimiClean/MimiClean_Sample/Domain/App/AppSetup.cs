using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App
{
    using IApp.IUseCase;
    using UseCase;

    /// <summary>
    /// App層のセットアップ機能を提供します
    /// </summary>
    public static class AppSetup
    {
        /// <summary>
        /// App層のデフォルトserviceをセットします。
        /// </summary>
        /// <typeparam name="TInt2D">利用する座標系</typeparam>
        /// <param name="container"></param>
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
