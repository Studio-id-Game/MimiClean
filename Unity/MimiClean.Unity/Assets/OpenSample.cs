using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class OpenSample : MonoBehaviour
{
    public static void Excute()
    {
        Debug.Log("Open sample project...");

        string unityEditorPath = EditorApplication.applicationPath;
        string projectPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "MimiClean.UnitySample"));

        Process.Start(new ProcessStartInfo
        {
            FileName = unityEditorPath,
            Arguments = $"-projectPath \"{projectPath}\"",
            UseShellExecute = false
        });
    }
}
