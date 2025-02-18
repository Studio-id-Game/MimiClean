namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal readonly struct AddItemInput(string name, int x, int y)
    {
        public readonly int x = x;
        public readonly int y = y;
        public readonly string name = name;
    }
}
