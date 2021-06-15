using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public string lookatObj = "UICamera";
    public Transform lookatTarget { get; set; } = null;
    public Vector3 offsetStart = new Vector3(0, .05f, 0);
    public string dialogContent = "";

    public Transform dialog;
    public Transform pointer;
    public LineRenderer lr;

    void Start()
    {
        lookatTarget = GameObject.Find(lookatObj).GetComponent<Transform>();
        if (dialog != null)
        {
            lr.startColor = dialog.GetComponent<Image>().color;
            lr.endColor = dialog.GetComponent<Image>().color;
        }

        dialog.localScale = Vector3.Scale(dialog.localScale, new Vector3(-1, 1, 1));
        pointer.localScale = Vector3.Scale(pointer.localScale, new Vector3(-1, 1, 1));

        lr.SetPosition(0, dialog.transform.position - offsetStart);
        lr.SetPosition(1, pointer.transform.position);

        dialog.GetChild(0).GetComponent<Text>().text = dialogContent;

        Canvas.ForceUpdateCanvases();
        dialog.GetChild(0).GetComponent<ContentSizeFitter>().enabled = false;
        dialog.GetChild(0).GetComponent<ContentSizeFitter>().enabled = true;
    }

    void Update()
    {
        if (lookatTarget == null)
            return;

        dialog.LookAt(lookatTarget);
        pointer.LookAt(lookatTarget);
    }
}
