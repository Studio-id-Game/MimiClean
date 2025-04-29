using StudioIdGames.MimiClean.App;

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
        public static void SetDefaultService()
        {
            MimiCleanAppSetup.SetDefaultService();
        }
    }
}
