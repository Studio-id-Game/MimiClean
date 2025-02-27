using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// MimiCleanのセットアップを行うための静的クラス
    /// </summary>
    public static class MimiCleanSetup
    {
        /// <summary>
        /// MimiCleanが内部で利用するサービスをセットアップします。
        /// </summary>
        /// <param name="container"></param>
        public static void SetDefaultService(MimiServiceContainer container)
        {
            Domain.App.MimiCleanAppSetup.SetDefaultService(container);
        }
    }
}
