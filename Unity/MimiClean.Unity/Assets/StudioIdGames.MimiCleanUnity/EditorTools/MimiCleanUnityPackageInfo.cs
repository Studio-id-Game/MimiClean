using UnityEditor;

namespace Assets.StudioIdGames.MimiCleanUnity.EditorTools
{
    /// <summary>
    /// MimiCleanUnityのパッケージの情報を提供します
    /// </summary>
    public static class MimiCleanUnityPackageInfo
    {
        /// <summary>
        /// このパッケージのシンプルな名前
        /// </summary>
        public const string PackageName = "MimiCleanUnity";

        /// <summary>
        /// このパッケージの <see cref="LibraryDependencies"/> の情報をjsonで保持するアセットのGUID
        /// </summary>
        public const string LibraryDependenciesJsonGUID = "0ed87e6756f618140b55131b9344acdb";

        /// <summary>
        /// このパッケージの <see cref="LibraryDependencies"/> の情報をjsonで保持するアセットのパス
        /// </summary>
        public static string LibraryDependenciesJsonPath => AssetDatabase.GUIDToAssetPath(LibraryDependenciesJsonGUID);

        /// <summary>
        /// このパッケージのルートアセンブリの一覧
        /// </summary>
        public static readonly string[] BaseAssemblyNames = new string[]
        {
            "StudioIdGames.MimiCleanUnity",
            "StudioIdGames.MimiCleanUnity.Editor",
            "StudioIdGames.MimiCleanUnity.EditorTools",
        };

        /// <summary>
        /// 依存関係として無視するアセンブリの一覧
        /// </summary>
        public static readonly string[] IgnoreAssemblyNames = new string[]
        {
            "Bee.BeeDriver",
            "Mono.Security",
            "mscorlib",
            "PlayerBuildProgramLibrary.Data",
            "System",
            "System.*",
            "Unity.*",
            "UnityEngine.*",
            "UnityEditor.*",
        };
    }
}
