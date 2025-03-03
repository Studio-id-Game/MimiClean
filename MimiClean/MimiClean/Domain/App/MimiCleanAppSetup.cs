using StudioIdGames.MimiCleanContainer;
using System;

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
        public static void SetDefaultService()
        {
            MimiServiceDefault.Set<ICurrentEntityService, CurrentEntityService>();
        }

        [Obsolete("Unused argument.")]
        public static void SetDefaultService(MimiServiceContainer _)
        {
            SetDefaultService();
        }
    }
}
