using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.StudioIdGames.MimiCleanUnity.EditorTools
{
    using static MimiCleanUnityPackageInfo;

    /// <summary>
    /// MimiCleanUnity パッケージが正常に導入できているかチェックするための機能セットです。
    /// 自動チェックとMenuItem（Tools/MimiCleanUnity/..）を提供します。
    /// </summary>
    public static class MimiCleanUnityPackageCheck
    {
        /// <summary>
        /// エディターロード時のコールバック。初回自動チェックの実施と、compile終了時の自動チェックの予約をします。
        /// </summary>
        [InitializeOnLoadMethod]
        public static void InitializeOnLoad()
        {
            Checker.AutoCheck();
            CompilationPipeline.compilationFinished += CompilationFinished;

            static void CompilationFinished(object obj)
            {
                CompilationPipeline.compilationFinished -= CompilationFinished;
                Checker.AutoCheck();
            }
            ;
        }

        /// <summary>
        /// 依存アセンブリをチェックします。
        /// </summary>
        [MenuItem("Tools/" + PackageName + "/Check Assemblies")]
        public static void CheckAssembliesMenuItem()
        {
            Checker.CheckAssemblies();
        }

        /// <summary>
        /// 依存アセンブリの一覧を表示します。
        /// </summary>
        [MenuItem("Tools/" + PackageName + "/Show Dependency Assemblies")]
        public static void ShowDependencyAssembliesMenuItem()
        {
            Checker.ShowDependencyAssemblies();
        }

        /// <summary>
        /// 自動で MimiCleanUnity.Library の更新を実行します。
        /// </summary>
        [MenuItem("Tools/" + PackageName + "/Update MimiCleanUnity.Library")]
        public static void UpdateMimiCleanUnityLibraryMenuItem()
        {
            Checker.UpdateMimiCleanUnityLibrary();
        }

        /// <summary>
        /// 自動で MimiCleanUnity.Library の再展開を実行します。
        /// </summary>
        [MenuItem("Tools/" + PackageName + "/Reload MimiCleanUnity.Library")]
        public static void ReloadMimiCleanUnityLibraryMenuItem()
        {
            Checker.ReloadMimiCleanUnityLibrary();
        }

        private static class Checker
        {
            internal static void AutoCheck()
            {
                var updated = ZipLibrary.Update(false);

                if (!CheckAssemblies(out var missingList))
                {
                    DisplayMissingDialog(missingList);
                }
            }

            internal static void CheckAssemblies()
            {
                if (CheckAssemblies(out var missingList))
                {
                    Debug.Log($"{PackageName} package is ready.\n{string.Join('\n', GetAssemblyDatas().Select(e => $"{e}"))}");
                }
                else
                {
                    DisplayMissingDialog(missingList);
                }
            }

            internal static void ShowDependencyAssemblies()
            {
                var sb = new StringBuilder();

                foreach (var item in GetAssemblyDatas())
                {
                    sb.AppendLine(item.ToString());
                }

                Debug.Log(sb.ToString());
            }

            internal static void UpdateMimiCleanUnityLibrary()
            {
                ZipLibrary.Update(true);
            }

            internal static void ReloadMimiCleanUnityLibrary()
            {
                ZipLibrary.Reload();
            }

            private static bool CheckAssemblies(out List<SimpleAssemblyData> missingList)
            {
                missingList = new List<SimpleAssemblyData>();
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assemblyData in GetAssemblyDatas())
                {
                    if (assemblies.All(asm => !assemblyData.Check(asm.GetName())))
                    {
                        missingList.Add(assemblyData);
                    }
                }

                return missingList.Count == 0;
            }

            private static void DisplayMissingDialog(List<SimpleAssemblyData> missingList)
            {
                if (EditorUtility.DisplayDialog(
                    $"Missing Dependency ({PackageName})",
                    $"Required assemblies :\n\n{string.Join("\n", missingList.Select(e => $"{e}"))}\n\n" +
                    $"Restarting the Editor may solve the problem. If not, please install them to use a {PackageName} package.",
                    "Restart Editor",
                    "Continue"
                ))
                {
                    string unityEditorPath = EditorApplication.applicationPath;
                    string projectPath = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
                    EditorApplication.OpenProject(projectPath);
                }
            }

            private static IEnumerable<SimpleAssemblyData> GetAssemblyDatas()
            {
                var jsonPath = LibraryDependenciesJsonPath;
                var jsonData = File.ReadAllText(jsonPath);
                var libraryDependencies = JsonUtility.FromJson<LibraryDependencies>(jsonData);

                return libraryDependencies.AssemblyDatas;
            }
        }

        // 今の所zip化すれば大した容量にならないので、Localに保存する
        private static class ZipLibrary
        {
            private const string OnlineLibraryDirectory = @"StudioIdGames.MimiCleanUnity.Library";
            private const string LibraryZipGUID = "24127a693dc0df6418dc11373a8f64dd";

            internal static bool Update(bool overwriteFiles)
            {
                var filePath = AssetDatabase.GUIDToAssetPath(LibraryZipGUID);
                var success = ExtraxtZip(filePath, overwriteFiles);

                if (success)
                {
                    AssetDatabase.Refresh();
                    CompilationPipeline.RequestScriptCompilation();
                }

                return success;
            }

            internal static bool Reload()
            {
                var assets = Application.dataPath;
                var libraryPath = Path.Combine(assets, Path.Combine(OnlineLibraryDirectory.Split('/')));
                Directory.Delete(libraryPath, true);
                return Update(true);
            }

            private static bool ExtraxtZip(string filePath, bool overwriteFiles)
            {
                var assets = Application.dataPath;
                var libraryPath = Path.Combine(assets, Path.Combine(OnlineLibraryDirectory.Split('/')));

                if (overwriteFiles)
                {
                    ZipFile.ExtractToDirectory(filePath, libraryPath, overwriteFiles);
                    return true;
                }
                else
                {
                    using var archive = ZipFile.OpenRead(filePath);
                    bool isUpdate = false;
                    foreach (var entry in archive.Entries)
                    {
                        if (string.IsNullOrEmpty(entry.Name))
                        {
                            Directory.CreateDirectory(Path.Combine(libraryPath, entry.FullName));
                            continue;
                        }

                        string entryPath = Path.Combine(libraryPath, entry.FullName);

                        if (!File.Exists(entryPath))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                            entry.ExtractToFile(entryPath);
                            isUpdate = true;
                        }
                    }

                    return isUpdate;
                }
            }
        }

        // 今の所zip化すれば大した容量にならないので、Localに保存する
        /*
        private static class OnlineZipLibrary
        {
            private const string OnlineLibraryDirectory = @"StudioIdGames.MimiCleanUnity.Library";

            private const string GoogleDriveFileID = "18hlsnrlxHUXzKV0Udi3X_UlNVqTI8plf";

            private const string DownloadURL = @"https://drive.google.com/uc?export=download&id=" + GoogleDriveFileID;

            private const string DownloadedFileName = "downloaded.zip.tmp";

            public static async Task<bool> Update(bool overwriteFiles)
            {
                var (success, filePath) = await DownloadZip(overwriteFiles);
                if (success)
                {
                    success = ExtraxtZip(filePath, overwriteFiles);
                }

                AssetDatabase.Refresh();

                if (success)
                {
                    CompilationPipeline.RequestScriptCompilation();
                }

                return success;
            }

            //https://drive.google.com/file/d/18hlsnrlxHUXzKV0Udi3X_UlNVqTI8plf/view?usp=sharing
            private static async Task<(bool success, string filePath)> DownloadZip(bool overwriteFiles)
            {
                var assets = Application.dataPath;
                var to = Path.Combine(assets, Path.Combine(OnlineLibraryDirectory.Split('/')));
                var filePath = Path.Combine(to, DownloadedFileName);
                var success = false;
                if (overwriteFiles || !File.Exists(filePath))
                {
                    if (!Directory.Exists(to))
                    {
                        Directory.CreateDirectory(to);
                    }

                    Debug.Log("CopyLibrary DownloadZip...");
                    using var client = new HttpClient();
                    var response = await client.GetAsync(DownloadURL);

                    success = response.IsSuccessStatusCode;
                    if (success)
                    {
                        await using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        await response.Content.CopyToAsync(fs);
                    }
                }
                else
                {
                    success = true;
                }

                return (success, filePath);
            }

            private static bool ExtraxtZip(string filePath, bool overwriteFiles)
            {
                var assets = Application.dataPath;
                var to = Path.Combine(assets, Path.Combine(OnlineLibraryDirectory.Split('/')));
                try
                {
                    ZipFile.ExtractToDirectory(filePath, to, overwriteFiles);
                    return true;
                }
                catch (IOException)
                {
                    return false;
                }
            }
        }
        */
    }
}
