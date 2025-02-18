namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal readonly struct MoveItemOutput(int movedX, int movedY)
    {
        public readonly int movedX = movedX;
        public readonly int movedY = movedY;
    }
}
