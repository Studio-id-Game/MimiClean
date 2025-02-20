using StudioIdGames.MimiClean.Domain;

namespace StudioIdGames.MimiCleanSample.Domain.Service
{
    internal interface IInt2DPosService : IService
    {
        public (int x, int y) Add((int x, int y) a, (int x, int y) b);
    }
}
