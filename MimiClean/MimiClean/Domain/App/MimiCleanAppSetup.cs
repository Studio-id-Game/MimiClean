using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using Service;

    public static class MimiCleanAppSetup
    {
        public static void SetDefaultService(MimiServiceContainer container)
        {
            MimiServiceDefault<ICurrentEntityService>.Set<CurrentEntityService>(container, 0);
        }
    }
}
