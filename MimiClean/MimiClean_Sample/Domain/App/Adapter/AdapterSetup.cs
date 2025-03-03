using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter
{
    using Controller;
    using Gateway;
    using IAdapter;
    using IApp.IRepository;
    using IApp.IService;
    using Presenter;
    using Repository;
    using Service;

    /// <summary>
    /// Adapter層のセットアップ機能を提供します
    /// </summary>
    public static class AdapterSetup
    {
        /// <summary>
        /// App層のデフォルトserviceをセットします。座標系としてタプルを利用します。
        /// </summary>
        public static void SetDefaultService_Tuple()
        {
            SetDefaultService<(int x, int y)>();
            MimiServiceDefault.Set<IInt2DService<(int x, int y)>, Int2DServiceTuple>();
        }

        /// <summary>
        /// App層のデフォルトserviceをセットします。座標系として配列を利用します。
        /// </summary>
        public static void SetDefaultService_Array()
        {
            SetDefaultService<int[]>();
            MimiServiceDefault.Set<IInt2DService<int[]>, Int2DServiceArray>();
        }

        [Obsolete("Unused arguments")]
        public static void SetDefaultService_Tuple(MimiServiceContainer? _)
        {
            SetDefaultService_Tuple();
        }

        [Obsolete("Unused arguments")]
        public static void SetDefaultService_Array(MimiServiceContainer? _)
        {
            SetDefaultService_Array();
        }

        private static void SetDefaultService<TInt2D>()
            where TInt2D : notnull
        {
            AppSetup.SetDefaultService<TInt2D>();
            SetDefaultRepository<TInt2D>();
            SetDefaultPresenter<TInt2D>();
            SetDefaultGateway<TInt2D>();
            SetDefaultController<TInt2D>();
        }

        private static void SetDefaultRepository<TInt2D>()
            where TInt2D : notnull
        {
            MimiServiceDefault.Set<IItemMapRepository<TInt2D>, ItemMapRepository<TInt2D>>();
            MimiServiceDefault.Ref<IItemMapRepository, IItemMapRepository<TInt2D>>();
            MimiServiceDefault.Set<IMapInfoRepository, MapInfoRepository10x10>();
        }

        private static void SetDefaultPresenter<TInt2D>()
        {
            MimiServiceDefault.Set<IAddItem.IPresenter, AddItemPresenter>();
            MimiServiceDefault.Set<IExit.IPresenter, ExitPresenter>();
            MimiServiceDefault.Set<IMoveItem.IPresenter, MoveItemPresenter>();
            MimiServiceDefault.Set<ISearchItems.IPresenter, SearchItemsPresenter>();
            MimiServiceDefault.Set<ISelectMainAction.IPresenter, SelectMainActionPresenter>();
        }

        private static void SetDefaultGateway<TInt2D>()
        {
            MimiServiceDefault.Set<IAddItem.IGateway, AddItemGateway>();
            MimiServiceDefault.Set<IExit.IGateway, ExitGateway>();
            MimiServiceDefault.Set<IMoveItem.IGateway, MoveItemGateway>();
            MimiServiceDefault.Set<ISearchItems.IGateway, SearchItemsGateway>();
            MimiServiceDefault.Set<ISelectMainAction.IGateway, SelectMainActionGateway>();
        }

        private static void SetDefaultController<TInt2D>()
        {
            MimiServiceDefault.Set<IAddItem, AddItem>();
            MimiServiceDefault.Set<IExit, Exit>();
            MimiServiceDefault.Set<IMoveItem, MoveItem>();
            MimiServiceDefault.Set<ISearchItems, SearchItems>();
            MimiServiceDefault.Set<ISelectMainAction, SelectMainAction>();
        }
    }
}
