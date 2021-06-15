using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    Camera uicam;

    // Start is called before the first frame update
    void Start()
    {
        uicam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        uicam.fieldOfView = Camera.main.fieldOfView;
    }
}
