using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public Data CurrentData;

    [Header("UI")]
    public GameObject custom;
    public GameObject rest;
    public new GameObject light;
    public GameObject pause;
    public GameObject fullscreen;
    public GameObject console;
    public Light[] alllights { get; set; }

    [Header("Others")]
    public GameObject floor;
    public GameObject postprocessingObj;
    public PostProcessLayer postProcessLayer;


    [Space]
    public TriggerEvent[] allTriggers;

    void Awake()
    {
        instance = this;
        StartCoroutine(Init());
        
        // Improve mobile performance
        //https://blog.unity.com/technology/how-on-demand-rendering-can-improve-mobile-performance
        //QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        // When the Menu starts, set the rendering to target 30fps
        OnDemandRendering.renderFrameInterval = 2;
    }

    private IEnumerator Init()
    {
        yield return new WaitUntil(LoadPrefabFromData);
        yield return new WaitUntil(LoadUISettingFromData);
        yield return new WaitUntil(LoadOthersFromData);
    }

    private bool LoadPrefabFromData()
    {
        for(int i=0; i<CurrentData.models.Length; i++)
            Instantiate(CurrentData.models[i]);

        allTriggers = FindObjectsOfType<TriggerEvent>();
        alllights = FindObjectsOfType<Light>();
        return true;
    }

    private bool LoadUISettingFromData()
    {
        custom.SetActive(CurrentData.EnableBtCustom);
        rest.SetActive(CurrentData.EnableBtReset);
        light.SetActive(CurrentData.EnableBtLight);
        pause.SetActive(CurrentData.EnableBtPause);
        fullscreen.SetActive(CurrentData.EnableBtFullscreen);
        console.SetActive(CurrentData.EnableBtConsole);
        GetComponent<Shinn.Console>().enabled = CurrentData.EnableBtConsole;
        return true;
    }

    private bool LoadOthersFromData()
    {
        floor.SetActive(CurrentData.EnableFloor);
        Camera.main.backgroundColor = CurrentData.Background;

        postprocessingObj.SetActive(CurrentData.EnablePostProcessing);
        postProcessLayer.enabled = CurrentData.EnablePostProcessing;
        GetComponent<FPSCounter>().enabled = CurrentData.ShowFPS;
        return true;
    }
}
