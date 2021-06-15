using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Custom : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenPage(string str);

    public void FullScreen()
    {
        //Screen.fullScreen = true;
#if !UNITY_EDITOR && UNITY_WEBGL
        OpenPage(DataManager.instance.CurrentData.WebglURL);
#elif UNITY_EDITOR
        Application.OpenURL(DataManager.instance.CurrentData.WebglURL);
#endif
    }

    public void TogglePause(bool toggle)
    {
        if (toggle)
        {
            DataManager.instance.pause.transform.GetChild(0).GetComponent<Text>().text = "Play";
            Time.timeScale = 0;
            print("pause");
        }
        else
        {
            DataManager.instance.pause.transform.GetChild(0).GetComponent<Text>().text = "Pause";
            Time.timeScale = 1;
            print("play");
        }
    }

    public void ToggleEnableLights(bool toggle)
    {
        foreach (var i in DataManager.instance.alllights)
            i.gameObject.SetActive(toggle);
    }
}
