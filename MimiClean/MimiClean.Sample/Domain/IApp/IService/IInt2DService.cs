using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IService
{
    [MimiServiceType(MimiServiceType.Static)]
    public interface IInt2DService<TInt2D> : IAppService
    {
        public TInt2D Add(in TInt2D a, in TInt2D b);

        public int GetX(in TInt2D pos);

        public int GetY(in TInt2D pos);

        public TInt2D New(int x, int y);
    }
}
