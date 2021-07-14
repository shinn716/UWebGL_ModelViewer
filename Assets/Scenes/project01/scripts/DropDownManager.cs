using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour
{
    public Dropdown dropdown;
    public Material targetMat;

    public void Init()
    {
        List<string> namelist = new List<string>();
        foreach (var i in LoadData.instace.allTextures)
            namelist.Add(i.name);

        dropdown.ClearOptions();
        dropdown.AddOptions(namelist);
        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });

        targetMat.mainTexture = LoadData.instace.allTextures[0].texture2d;
    }

    private void DropdownValueChanged(Dropdown change)
    {
        print(change.value);
        targetMat.mainTexture = LoadData.instace.allTextures[change.value].texture2d;
    }
}
