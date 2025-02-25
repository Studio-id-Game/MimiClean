using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiCleanSample.IDomain.IModule
{
    public interface IItemModuleSet : IDomainModuleSet
    {

    }

    public interface IItemModuleSet<TInt2D> : IItemModuleSet
    {
        INameModule NameModule { get; }

        IInt2DPosModule<TInt2D> Int2DPosModule { get; }

        public string ItemName { get; set; }

        public TInt2D XY { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
