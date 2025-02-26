using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean
{
    public static class MimiCleanSetup
    {
        public static void SetDefaultService(MimiServiceContainer container)
        {
            Domain.App.MimiCleanAppSetup.SetDefaultService(container);
        }
    }
}
