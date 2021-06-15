using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public int FPS { get; private set; }

    private void Start()
    {
        InvokeRepeating(nameof(UpdateFPS), 0, .25F);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 24, 0, Screen.width, Screen.height), FPS.ToString());
    }

    private void UpdateFPS()
    {
        FPS = (int)(1f / Time.unscaledDeltaTime);
    }
}
