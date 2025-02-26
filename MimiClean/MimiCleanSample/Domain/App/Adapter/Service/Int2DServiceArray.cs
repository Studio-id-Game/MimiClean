namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Service
{
    using IApp.IService;

    internal class Int2DServiceArray : IInt2DService<int[]>
    {
        public int[] Add(in int[] a, in int[] b)
        {
            return [a[0] + b[0], a[1] + b[1]];
        }

        public int GetX(in int[] pos)
        {
            return pos[0];
        }

        public int GetY(in int[] pos)
        {
            return pos[1];
        }

        public int[] New(int x, int y)
        {
            return [x, y];
        }
    }
}
