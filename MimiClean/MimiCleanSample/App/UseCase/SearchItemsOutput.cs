namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal readonly struct SearchItemsOutput(IEnumerable<(int x, int y)> positions)
    {
        public readonly IEnumerable<(int x, int y)> positions = positions;

        public readonly bool find = positions.Any();
    }
}
