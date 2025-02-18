namespace StudioIdGames.MimiClean
{
    public interface ICleanResultBoxed
    {
        CleanResultState State { get; }
        CleanResultError Error { get; }

        bool IsSuccess { get; }
        bool IsCanceled { get; }
        bool IsFailed { get; }
    }

}
