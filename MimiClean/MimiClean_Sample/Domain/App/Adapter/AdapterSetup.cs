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

    public static class AdapterSetup
    {
        public static void SetDefaultService_Tuple(MimiServiceContainer container)
        {
            SetDefaultService<(int x, int y)>(container);
            MimiServiceDefault<IInt2DService<(int x, int y)>>.Set<Int2DServiceTuple>(container, 0);
        }

        public static void SetDefaultService_Array(MimiServiceContainer container)
        {
            SetDefaultService<int[]>(container);
            MimiServiceDefault<IInt2DService<int[]>>.Set<Int2DServiceArray>(container, 0);
        }

        private static void SetDefaultService<TInt2D>(MimiServiceContainer container)
            where TInt2D : notnull
        {
            AppSetup.SetDefaultService<TInt2D>(container);
            SetDefaultRepository<TInt2D>(container);
            SetDefaultPresenter<TInt2D>(container);
            SetDefaultGateway<TInt2D>(container);
            SetDefaultController<TInt2D>(container);
        }

        private static void SetDefaultRepository<TInt2D>(MimiServiceContainer container)
            where TInt2D : notnull
        {
            MimiServiceDefault<IItemMapRepository<TInt2D>>.Set<ItemMapRepository<TInt2D>>(container, 0);
            MimiServiceDefault<IItemMapRepository>.Ref<IItemMapRepository<TInt2D>>(container, 0);
            MimiServiceDefault<IMapInfoRepository>.Set<MapInfoRepository10x10>(container, 0);
        }

        private static void SetDefaultPresenter<TInt2D>(MimiServiceContainer container)
        {
            MimiServiceDefault<IAddItem.IPresenter>.Set<AddItemPresenter>(container, 0);
            MimiServiceDefault<IExit.IPresenter>.Set<ExitPresenter>(container, 0);
            MimiServiceDefault<IMoveItem.IPresenter>.Set<MoveItemPresenter>(container, 0);
            MimiServiceDefault<ISearchItems.IPresenter>.Set<SearchItemsPresenter>(container, 0);
            MimiServiceDefault<ISelectMainAction.IPresenter>.Set<SelectMainActionPresenter>(container, 0);
        }

        private static void SetDefaultGateway<TInt2D>(MimiServiceContainer container)
        {
            MimiServiceDefault<IAddItem.IGateway>.Set<AddItemGateway>(container, 0);
            MimiServiceDefault<IExit.IGateway>.Set<ExitGateway>(container, 0);
            MimiServiceDefault<IMoveItem.IGateway>.Set<MoveItemGateway>(container, 0);
            MimiServiceDefault<ISearchItems.IGateway>.Set<SearchItemsGateway>(container, 0);
            MimiServiceDefault<ISelectMainAction.IGateway>.Set<SelectMainActionGateway>(container, 0);
        }

        private static void SetDefaultController<TInt2D>(MimiServiceContainer container)
        {
            MimiServiceDefault<IAddItem>.Set<AddItem>(container, 0);
            MimiServiceDefault<IExit>.Set<Exit>(container, 0);
            MimiServiceDefault<IMoveItem>.Set<MoveItem>(container, 0);
            MimiServiceDefault<ISearchItems>.Set<SearchItems>(container, 0);
            MimiServiceDefault<ISelectMainAction>.Set<SelectMainAction>(container, 0);
        }
    }
}
