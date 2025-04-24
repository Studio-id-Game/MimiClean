using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.StudioIdGames.MimiCleanUnity.EditorTools
{
    /// <summary>
    /// パッケージが依存するライブラリのアセンブリのリスト
    /// </summary>
    [Serializable]
    public class LibraryDependencies
    {
        [SerializeField]
        private string packageName;

        [SerializeField]
        private string[] assemblyDatas;

        /// <summary>
        /// パッケージ名
        /// </summary>
        public string PackageName => packageName;

        /// <summary>
        /// アセンブリリスト
        /// </summary>
        public IEnumerable<SimpleAssemblyData> AssemblyDatas => assemblyDatas?.Select(e => new SimpleAssemblyData(e)) ?? Array.Empty<SimpleAssemblyData>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="packageName"></param>
        /// <param name="assemblyDatas"></param>
        public LibraryDependencies(string packageName, SimpleAssemblyData[] assemblyDatas)
        {
            this.packageName = packageName;
            this.assemblyDatas = assemblyDatas.Select(e => e.ToString()).ToArray();
        }
    }
}
