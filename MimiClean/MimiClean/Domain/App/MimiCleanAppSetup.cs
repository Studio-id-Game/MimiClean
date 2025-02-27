using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using Service;

    /// <summary>
    /// MimiCleanのApp層のセットアップを行うための静的クラス
    /// </summary>
    public static class MimiCleanAppSetup
    {
        /// <summary>
        /// MimiCleanのApp層が内部で利用するサービスをセットアップします。
        /// </summary>
        /// <param name="container"></param>
        public static void SetDefaultService(MimiServiceContainer container)
        {
            MimiServiceDefault<ICurrentEntityService>.Set<CurrentEntityService>(container, 0);
        }
    }
}
