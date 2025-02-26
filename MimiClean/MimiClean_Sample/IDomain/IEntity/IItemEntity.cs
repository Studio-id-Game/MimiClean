using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.IDomain.IEntity
{
    using IDomain.IModule;

    public interface IItemEntity : IDomainEntity
    {
        public string ItemName { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }

    public interface IItemEntity<TInt2D> : IItemEntity
    {
        IItemModuleSet<TInt2D> ItemModuleSet { get; }

        public TInt2D XY { get; set; }
    }
}
