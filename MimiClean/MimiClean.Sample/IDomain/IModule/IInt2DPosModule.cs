using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiCleanSample.IDomain.IModule
{
    public interface IInt2DPosModule : IDomainModule
    {
    }

    public interface IInt2DPosModule<TInt2D> : IInt2DPosModule
    {
        public TInt2D XY { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
