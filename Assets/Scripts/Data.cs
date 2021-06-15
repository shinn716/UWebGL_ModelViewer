using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data : ScriptableObject
{
    [Header("URL")]
    public string WebglURL = "http://www.unity3d.com";

    [Header("Load prefab")]
    public GameObject[] models;

    [Header("UI")]
    public bool EnableBtCustom = false;
    public bool EnableBtReset = true;
    public bool EnableBtLight = true;
    public bool EnableBtPause = true;
    public bool EnableBtFullscreen = true;
    public bool EnableBtConsole = true;

    [Header("Others")]
    public bool EnableFloor = false;
    public bool EnablePostProcessing = false;
    public bool ShowFPS = false;
    public Color Background = Color.black;
}