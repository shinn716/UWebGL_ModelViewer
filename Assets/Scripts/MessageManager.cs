using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.ExternalCall("getDeviceJudgment");
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void FromHtml_str(string input)
    {
        switch (input)
        {
            default:
                print("[type]"+ input);
                break;
            case "Desktop":
                print("[type]" + input);
                break;
            case "Mobile":
                print("[type]" + input);
                break;
        }
    }
}
