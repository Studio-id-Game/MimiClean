using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain
{
    using Entity;
    using EntityConfig;
    using IDomain.IEntity;
    using IDomain.IModule;
    using Module;

    /// <summary>
    /// Domain層のセットアップ機能を提供します
    /// </summary>
    public static class DomainSetup
    {
        /// <summary>
        /// Domain層のデフォルトserviceをセットします。
        /// </summary>
        /// <typeparam name="TInt2D">利用する座標系</typeparam>
        public static void SetDefaultService<TInt2D>()
        {
            MimiServiceDefault.Set<IItemEntity<TInt2D>, ItemEntity<TInt2D>>();
            MimiServiceDefault.Ref<IItemEntity, IItemEntity<TInt2D>>();
            MimiServiceDefault.Set<IMapInfoEntity, MapInfoEntity>();
            MimiServiceDefault.Set<MapInfoConfig>();
            MimiServiceDefault.Set<IInt2DPosModule<TInt2D>, Int2DPosModule<TInt2D>>();
            MimiServiceDefault.Ref<IInt2DPosModule, IInt2DPosModule<TInt2D>>();
            MimiServiceDefault.Set<IItemModuleSet<TInt2D>, ItemModuleSet<TInt2D>>();
            MimiServiceDefault.Ref<IItemModuleSet, IItemModuleSet<TInt2D>>();
            MimiServiceDefault.Set<INameModule, NameModule>();
        }

        [Obsolete("Unused arguments")]
        public static void SetDefaultService<TInt2D>(MimiServiceContainer _)
        {
            SetDefaultService<TInt2D>();
        }
    }
}
