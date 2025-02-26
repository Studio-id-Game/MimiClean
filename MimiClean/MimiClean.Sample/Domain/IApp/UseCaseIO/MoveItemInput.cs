namespace StudioIdGames.MimiCleanSample.Domain.IApp.UseCaseIO
{
    public readonly struct MoveItemInput(string name, int dx, int dy)
    {
        public readonly string name = name;
        public readonly int dx = dx;
        public readonly int dy = dy;
    }
}
