// Close unity-webgl-warning for mobile.
// Source: https://answers.unity.com/questions/1339261/unity-webgl-disable-mobile-warning.html

using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class PostBuildActions
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string targetPath)
    {
        Debug.Log("Called from OnPostprocessBuild: " + targetPath);
        var path = Path.Combine(targetPath, "Build/UnityLoader.js");
        var text = File.ReadAllText(path);
        text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
        File.WriteAllText(path, text);
    }
}