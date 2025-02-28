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
        /// <param name="container"></param>
        public static void SetDefaultService<TInt2D>(MimiServiceContainer container)
        {
            MimiServiceDefault<IItemEntity<TInt2D>>.Set<ItemEntity<TInt2D>>(container, 0);
            MimiServiceDefault<IItemEntity>.Ref<IItemEntity<TInt2D>>(container, 0);
            MimiServiceDefault<IMapInfoEntity>.Set<MapInfoEntity>(container, 0);
            MimiServiceDefault<MapInfoConfig>.Set<MapInfoConfig>(container, 0);
            MimiServiceDefault<IInt2DPosModule<TInt2D>>.Set<Int2DPosModule<TInt2D>>(container, 0);
            MimiServiceDefault<IInt2DPosModule>.Ref<IInt2DPosModule<TInt2D>>(container, 0);
            MimiServiceDefault<IItemModuleSet<TInt2D>>.Set<ItemModuleSet<TInt2D>>(container, 0);
            MimiServiceDefault<IItemModuleSet>.Ref<IItemModuleSet<TInt2D>>(container, 0);
            MimiServiceDefault<INameModule>.Set<NameModule>(container, 0);
        }
    }
}
