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
#pragma warning disable CS0618 // 型またはメンバーが旧型式です
            MimiServiceDefault.Set<ICurrentEntityService, CurrentEntityService>();
#pragma warning restore CS0618 // 型またはメンバーが旧型式です
        }

        /// <summary>
        /// 非推奨
        /// </summary>
        /// <param name="_"></param>
        [Obsolete("Unused argument.")]
        public static void SetDefaultService(MimiServiceContainer _)
        {
            SetDefaultService();
        }
    }
}
