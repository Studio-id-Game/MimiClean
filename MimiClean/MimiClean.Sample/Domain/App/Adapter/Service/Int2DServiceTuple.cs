namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Service
{
    using IApp.IService;

    internal class Int2DServiceTuple : IInt2DService<(int x, int y)>
    {
        public (int x, int y) Add(in (int x, int y) a, in (int x, int y) b)
        {
            return (a.x + b.x, a.y + b.y);
        }

        public int GetX(in (int x, int y) pos)
        {
            return pos.x;
        }

        public int GetY(in (int x, int y) pos)
        {
            return pos.y;
        }

        public (int x, int y) New(int x, int y)
        {
            return (x, y);
        }
    }
}
