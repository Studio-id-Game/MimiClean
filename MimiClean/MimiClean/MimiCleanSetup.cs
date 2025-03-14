﻿using StudioIdGames.MimiCleanContainer;
using System;

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
            Domain.App.MimiCleanAppSetup.SetDefaultService();
        }

        /// <summary>
        /// MimiCleanが内部で利用するサービスをセットアップします。
        /// </summary>
        /// <param name="_">未使用</param>
        [Obsolete("Unused arguments")]
        public static void SetDefaultService(MimiServiceContainer _)
        {
            Domain.App.MimiCleanAppSetup.SetDefaultService();
        }
    }
}
