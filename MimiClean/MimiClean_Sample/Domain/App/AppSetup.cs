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
        public static void SetDefaultService<TInt2D>()
        {
            DomainSetup.SetDefaultService<TInt2D>();

            MimiServiceDefault.Set<IAddItemUseCase, AddItemUseCase<TInt2D>>();
            MimiServiceDefault.Set<IExitUseCase, ExitUseCase>();
            MimiServiceDefault.Set<IMoveItemUseCase, MoveItemUseCase<TInt2D>>();
            MimiServiceDefault.Set<ISearchItemsUseCase, SearchItemsUsecase<TInt2D>>();
            MimiServiceDefault.Set<ISelectMainActionUseCase, SelectMainActionUseCase>();
        }

        [Obsolete("Unused arguments")]
        public static void SetDefaultService<TInt2D>(MimiServiceContainer container)
        {
            SetDefaultService<TInt2D>();
        }
    }
}
