using StudioIdGames.MimiClean.Domain;

namespace StudioIdGames.MimiCleanSample.Domain.Service
{
    public interface IInt2DPosService : IService
    {
        public (int x, int y) Add((int x, int y) a, (int x, int y) b);
    }
}
