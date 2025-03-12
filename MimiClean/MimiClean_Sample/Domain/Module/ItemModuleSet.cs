namespace StudioIdGames.MimiClean_Sample.Domain.Module
{
    using StudioIdGames.MimiClean.Domain;
    using StudioIdGames.MimiClean_Sample.Domain.IApp.IService;
    using StudioIdGames.MimiClean_Sample.IDomain;
    using System;

    /// <summary>
    /// <see cref="IItemProperty{TInt2D}"/>を実装するモジュールセットです。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    /// <param name="nameModule"></param>
    /// <param name="int2DPosModule"></param>
    /// <param name="currentEntity"></param>
    /// <param name="moduleName"></param>
    public sealed class ItemModuleSet<TInt2D>(DomainEntity entity, Func<IInt2DService<TInt2D>> int2D, string? nameModuleName = null, string? int2DPosModuleName = null, string? moduleName = null) :
        DomainModuleSet(entity, moduleName), IItemProperty<TInt2D>
    {
        /// <inheritdoc />
        public override int Count => base.Count + 2;

        /// <inheritdoc cref="IItemProperty.ItemNameProperty"/>
        public ItemNameModule ItemNameProperty { get; } = new ItemNameModule(entity, nameModuleName);

        /// <inheritdoc />
        IItemNameProperty IItemProperty.ItemNameProperty => ItemNameProperty;

        /// <inheritdoc cref="IItemProperty.Int2DPosProperty"/>
        public Int2DPosModule<TInt2D> Int2DPosProperty { get; } = new Int2DPosModule<TInt2D>(entity, int2D, int2DPosModuleName);

        /// <inheritdoc/>
        IInt2DPosProperty<TInt2D> IItemProperty<TInt2D>.Int2DPosProperty => Int2DPosProperty;

        /// <inheritdoc/>
        IInt2DPosProperty IItemProperty.Int2DPosProperty => Int2DPosProperty;

        /// <inheritdoc/>
        public string ItemName { get => ItemNameProperty.ItemName; set => ItemNameProperty.ItemName = value; }

        /// <inheritdoc/>
        public TInt2D XY { get => Int2DPosProperty.XY; set => Int2DPosProperty.XY = value; }

        /// <inheritdoc/>
        public int X { get => Int2DPosProperty.X; set => Int2DPosProperty.X = value; }

        /// <inheritdoc/>
        public int Y { get => Int2DPosProperty.Y; set => Int2DPosProperty.Y = value; }

        public override IEnumerable<T> Get_v2<T>(Predicate<T>? match = null)
        {
            if (match == null)
            {
                if (ItemNameProperty is T nameModuleT) yield return nameModuleT;
                if (Int2DPosProperty is T int2DPosModuleT) yield return int2DPosModuleT;
            }
            else
            {
                if (ItemNameProperty is T nameModuleT && match(nameModuleT)) yield return nameModuleT;
                if (Int2DPosProperty is T int2DPosModuleT && match(int2DPosModuleT)) yield return int2DPosModuleT;
            }

            foreach (var item in base.Get_v2<T>())
            {
                yield return item;
            }
        }

        public override IEnumerator<DomainModule> GetEnumerator_v2()
        {
            yield return ItemNameProperty;
            yield return Int2DPosProperty;
            foreach (var module in CustomModules_v2)
            {
                yield return module;
            }
        }
    }
}
