namespace StudioIdGames.MimiClean_Sample.Domain
{
    using StudioIdGames.MimiCleanContainer;

    /// <summary>
    /// Domain層のセットアップ機能を提供します
    /// </summary>
    public static class DomainSetup
    {
        /// <summary>
        /// Domain層のデフォルトserviceをセットします。
        /// </summary>
        /// <typeparam name="TInt2D">利用する座標系</typeparam>
        public static void SetDefaultService<TInt2D>()
        {
        }

        [Obsolete("Unused arguments")]
        public static void SetDefaultService<TInt2D>(MimiServiceContainer _)
        {
            SetDefaultService<TInt2D>();
        }
    }
}
