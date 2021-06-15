using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public bool hightlightEnable = true;
    public UnityEvent triggerEvent;
    public UnityEvent enterEvent;
    public UnityEvent exitEvent;

    private MeshFilter mf;
    private GameObject goClone;
    private bool flag = false;

    private void Start()
    {
        mf = GetComponent<MeshFilter>();
    }

    private void Action(string message)
    {
        switch (message)
        {
            case "enter":
                enterEvent.Invoke();

                if (!hightlightEnable)
                    return;

                if (flag)
                    return;

                goClone = new GameObject(name + "(Clone)");
                goClone.transform.SetParent(transform);
                goClone.transform.localPosition = Vector3.zero;
                goClone.transform.localRotation = Quaternion.identity;
                goClone.transform.localScale = Vector3.one;

                goClone.AddComponent<MeshFilter>();
                goClone.AddComponent<MeshRenderer>();

                goClone.GetComponent<MeshFilter>().mesh = mf.mesh;
                goClone.GetComponent<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
                goClone.GetComponent<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
                goClone.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                goClone.GetComponent<MeshRenderer>().receiveShadows = false;
                goClone.GetComponent<MeshRenderer>().material = Resources.Load<Material>("yellow");

                flag = true;
                break;

            case "exit":
                exitEvent.Invoke();

                if (!hightlightEnable)
                    return;

                if (goClone != null)
                    Destroy(goClone);

                flag = false;
                break;
        }
    }

    private void Trigger(Vector3 hitPoint)
    {
        print("[Trigger]" + name + " " + hitPoint);
        triggerEvent.Invoke();
    }
}
