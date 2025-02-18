using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiCleanSample.Domain.Service;

namespace StudioIdGames.MimiCleanSample.Adapter.Service
{
    public class Int2DPosService01 : Service<IInt2DPosService, Int2DPosService01>, IInt2DPosService
    {
        public (int x, int y) Add((int x, int y) a, (int x, int y) b)
        {
            return (a.x + b.x, a.y + b.y);
        }
    }

    /// <summary>
    /// Dummy Test
    /// </summary>
    public class Int2DPosService02 : Service<IInt2DPosService, Int2DPosService02>, IInt2DPosService
    {
        /// <summary>
        /// Dummy Test
        /// </summary>
        public (int x, int y) Add((int x, int y) a, (int x, int y) b)
        {
            return (0, 0);
        }
    }
}
