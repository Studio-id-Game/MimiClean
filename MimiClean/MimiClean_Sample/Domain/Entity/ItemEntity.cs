namespace StudioIdGames.MimiClean_Sample.Domain.Entity
{
    using IDomain;
    using Module;
    using StudioIdGames.MimiClean.Domain;
    using StudioIdGames.MimiClean_Sample.Domain.IApp.IService;

    /// <summary>
    /// <see cref="IItemProperty{TInt2D}"/> を実装するエンティティです。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    public sealed class ItemEntity<TInt2D> : DomainEntity, IItemProperty<TInt2D>
    {
        public ItemEntity(Func<IInt2DService<TInt2D>> int2D)
        {
            ItemModuleSet = new ItemModuleSet<TInt2D>(this, int2D);
        }

        /// <inheritdoc/>
        public override IEnumerable<T> M_v2<T>() => ItemModuleSet.Get_v2<T>();

        /// <summary>
        /// アイテムを定義するモジュールセット
        /// </summary>
        public ItemModuleSet<TInt2D> ItemModuleSet { get; }

        /// <inheritdoc/>
        public string ItemName { get => ItemModuleSet.ItemName; set => ItemModuleSet.ItemName = value; }

        /// <inheritdoc/>
        public TInt2D XY { get => ItemModuleSet.XY; set => ItemModuleSet.XY = value; }

        /// <inheritdoc/>
        public int X { get => ItemModuleSet.X; set => ItemModuleSet.X = value; }

        /// <inheritdoc/>
        public int Y { get => ItemModuleSet.Y; set => ItemModuleSet.Y = value; }

        /// <inheritdoc/>
        public IInt2DPosProperty<TInt2D> Int2DPosProperty => ((IItemProperty<TInt2D>)ItemModuleSet).Int2DPosProperty;

        /// <inheritdoc/>
        public IItemNameProperty ItemNameProperty => ((IItemProperty)ItemModuleSet).ItemNameProperty;

        /// <inheritdoc/>
        IInt2DPosProperty IItemProperty.Int2DPosProperty => ((IItemProperty)ItemModuleSet).Int2DPosProperty;
    }
}
