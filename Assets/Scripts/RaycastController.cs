using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public bool debugEnable = false;
    public GameObject sprDot;

    private GameObject currObj;
    private GameObject prevObj;

    // Start is called before the first frame update
    void Start()
    {
        if (!debugEnable)
            sprDot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Raycaster();
    }


    private void Raycaster()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            sprDot.transform.position = hit.point;
            sprDot.transform.LookAt(Camera.main.transform);

            if (hit.collider != null)
            {
                currObj = hit.collider.gameObject;

                if (prevObj != null)
                {
                    if (currObj.name != prevObj.name)
                    {
                        prevObj.SendMessage("Action", "exit", SendMessageOptions.DontRequireReceiver);
                        prevObj = null;
                    }
                }

                // touch
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase.Equals(TouchPhase.Began))
                    {
                        currObj.SendMessage("Trigger", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
                // click
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        currObj.SendMessage("Trigger", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }

                currObj.SendMessage("Action", "enter", SendMessageOptions.DontRequireReceiver);
                prevObj = currObj;
            }
        }
        else
        {
            if (currObj == null)
                return;

            currObj.SendMessage("Action", "exit", SendMessageOptions.DontRequireReceiver);
            currObj = null;
        }
    }
}
