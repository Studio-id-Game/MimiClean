using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.StudioIdGames.MimiCleanUnity.EditorTools
{
    /// <summary>
    /// アセンブリの名前とVersionを表すオブジェクト
    /// </summary>
    [Serializable]
    public class SimpleAssemblyData : IEquatable<SimpleAssemblyData>
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private string version;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="text"><c>"Name : Version"</c> or <c>"Name"</c></param>
        public SimpleAssemblyData(string text)
        {
            var nameVersion = text.Split(':');
            name = nameVersion[0].Trim();
            version = nameVersion.Length < 2 ? "0.0.0.0" : nameVersion[1].Trim();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="assembly"></param>
        public SimpleAssemblyData(AssemblyName assembly)
        {
            name = assembly.Name;
            version = assembly.Version.ToString();
        }

        /// <summary>
        /// アセンブリ名
        /// </summary>
        public string Name => name;

        /// <summary>
        /// アセンブリバージョン
        /// </summary>
        public Version Version => new(version);

        /// <summary>
        /// 引数の <see cref="AssemblyName"/> が、この要件を満たしているかチェックします。
        /// </summary>
        /// <param name="name"></param>
        /// <returns>要件を満たしている場合true、そうでないときfalseを返します。</returns>
        public bool Check(AssemblyName name)
        {
            return name.Name == Name && name.Version >= Version;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SimpleAssemblyData);
        }

        public bool Equals(SimpleAssemblyData other)
        {
            return other is not null &&
                   Name == other.Name &&
                   EqualityComparer<Version>.Default.Equals(Version, other.Version);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Version);
        }

        /// <summary>
        /// <c>"Name : Version"</c>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} : {Version}";
        }

        public static bool operator ==(SimpleAssemblyData left, SimpleAssemblyData right)
        {
            return EqualityComparer<SimpleAssemblyData>.Default.Equals(left, right);
        }

        public static bool operator !=(SimpleAssemblyData left, SimpleAssemblyData right)
        {
            return !(left == right);
        }
    }
}
