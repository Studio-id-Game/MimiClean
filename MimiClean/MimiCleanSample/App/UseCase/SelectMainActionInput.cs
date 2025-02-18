using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal readonly struct SelectMainActionInput(MainActions mainAction, bool useDummy)
    {
        public readonly MainActions mainAction = mainAction;
        public readonly bool useDummy = useDummy;
    }
}
