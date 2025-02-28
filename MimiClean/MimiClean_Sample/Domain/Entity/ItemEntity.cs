using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.Entity
{
    using IDomain.IEntity;
    using IDomain.IModule;

    /// <summary>
    /// <see cref="IItemEntity{TInt2D}"/> を実装します。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    public sealed class ItemEntity<TInt2D> : DomainEntity, IItemEntity<TInt2D>
    {
        public ItemEntity(MimiServiceProvider serviceProvider) : base(serviceProvider)
        {
            using var _ = new CreateEntityScope(serviceProvider, this);

            ItemModuleSet = serviceProvider.GetService<IItemModuleSet<TInt2D>>();
        }

        public IItemModuleSet<TInt2D> ItemModuleSet { get; }

        IItemModuleSet IItemEntity.ItemModuleSet => ItemModuleSet;

        public string ItemName { get => ItemModuleSet.ItemName; set => ItemModuleSet.ItemName = value; }

        public TInt2D XY { get => ItemModuleSet.XY; set => ItemModuleSet.XY = value; }

        public int X { get => ItemModuleSet.X; set => ItemModuleSet.X = value; }

        public int Y { get => ItemModuleSet.Y; set => ItemModuleSet.Y = value; }

        public override IEnumerable<T> M<T>() => ItemModuleSet.Get<T>();
    }
}
