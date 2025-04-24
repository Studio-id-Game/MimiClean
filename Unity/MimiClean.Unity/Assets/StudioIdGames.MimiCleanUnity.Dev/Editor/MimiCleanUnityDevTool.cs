using Assets.StudioIdGames.MimiCleanUnity.EditorTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace Assets.StudioIdGames.MimiCleanUnity.Dev.Editor
{
    using static MimiCleanUnityPackageInfo;

    /// <summary>
    /// MimiCleanUnityの開発中に利用するツール機能セットです。
    /// </summary>
    public static class MimiCleanUnityDevTool
    {
        private const string LibraryDependenciesJsonSavePath = "Assets/StudioIdGames.MimiCleanUnity/Editor/LibraryDependencies.json";

        /// <summary>
        /// MimiCleanUnityの LibraryDependencies.json を更新します。
        /// 内容は、<see cref="BaseAssemblyNames"/> に一致するアセンブリから再帰的に依存関係を取得し、
        /// <see cref="IgnoreAssemblyNames"/> に一致するアセンブリを除いた物です。
        /// また、"Unity." "UnityEngine." "UnityEditor." から始まるアセンブリも無視します。
        /// </summary>
        [MenuItem("Tools/MimiCleanUnity/[Dev] Update LibraryDependencies.json")]
        public static void UpdateLibraryDependenciesJsonMenuItem()
        {
            var referencedAssemblies = GetReferencedAssemblies();
            var libraryDependencies = new LibraryDependencies(PackageName, referencedAssemblies);
            var jsonData = JsonUtility.ToJson(libraryDependencies, true);
            var jsonPath = LibraryDependenciesJsonSavePath;

            File.WriteAllText(jsonPath, jsonData);
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 現在の環境でロードされている全てのアセンブリの名前とバージョンを表示します。
        /// </summary>
        [MenuItem("Tools/MimiCleanUnity/[Dev] Show All Assembly")]
        public static void ShowAllAssemblyMenuItem()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Debug.Log(string.Join('\n', assemblies.Select(e => $"{e.GetName().Name} : {e.GetName().Version}").OrderBy(e => e)));
        }

        private static SimpleAssemblyData[] GetReferencedAssemblies()
        {
            var hashSet = new HashSet<SimpleAssemblyData>();
            var checkList = new Stack<SimpleAssemblyData>(
                BaseAssemblyNames
                .Select(e => new SimpleAssemblyData(e))
                .Where(e =>
                {
                    try
                    {
                        Assembly.Load(e.Name);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                })
            );
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            while (checkList.TryPop(out var asmData))
            {
                try
                {
                    var targetAssembly = Assembly.Load(asmData.Name);
                    var referencedAssemblies = targetAssembly.GetReferencedAssemblies();
                    if (AddToHashSet(asmData) && referencedAssemblies.Length > 0)
                    {
                        foreach (var referencedAssembly in referencedAssemblies)
                        {
                            var data = new SimpleAssemblyData(referencedAssembly);
                            checkList.Push(data);
                        }
                    }
                }
                catch (Exception)
                {
                    AddToHashSet(asmData);
                }
            }

            bool AddToHashSet(SimpleAssemblyData data)
            {
                if (allAssemblies.Any(e => data.Check(e.GetName())))
                {
                    var prev = hashSet.FirstOrDefault(e => e.Name == data.Name);
                    if (prev == default)
                    {
                        return hashSet.Add(data);
                    }
                    else if (prev.Version > data.Version)
                    {
                        return false;
                    }
                    else
                    {
                        hashSet.Remove(prev);
                        hashSet.Add(data);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            hashSet.RemoveWhere(e => IgnoreAssemblyNames.Any(f =>
            {
                var fData = new SimpleAssemblyData(f);
                string regexPattern = "^" + Regex.Escape(fData.Name)
                                                .Replace(@"\*", ".*")
                                                .Replace(@"\?", ".") + "$";
                return Regex.IsMatch(e.Name, regexPattern);
            }));

            hashSet.RemoveWhere(e => BaseAssemblyNames.Any(f =>
            {
                var fData = new SimpleAssemblyData(f);
                return fData.Name == e.Name;
            }));

            return hashSet.OrderBy(e => e.Name).ToArray();
        }
    }
}
