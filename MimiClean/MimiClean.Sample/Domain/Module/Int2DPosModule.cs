using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiClean.Domain.IApp;

namespace StudioIdGames.MimiClean_Sample.Domain.Module
{
    using IApp.IService;
    using IDomain.IModule;

    public sealed class Int2DPosModule<TInt2D>(IInt2DService<TInt2D> int2d, ICurrentEntityService currentEntity, string? moduleName = null) : DomainModule(currentEntity, moduleName), IInt2DPosModule<TInt2D>
    {
        private readonly IInt2DService<TInt2D> int2d = int2d;

        public int X
        {
            get => int2d.GetX(XY);
            set => XY = int2d.New(value, int2d.GetY(XY));
        }

        public int Y
        {
            get => int2d.GetY(XY);
            set => XY = int2d.New(int2d.GetX(XY), value);
        }

        public TInt2D XY { get; set; } = int2d.New(0, 0);
    }
}
