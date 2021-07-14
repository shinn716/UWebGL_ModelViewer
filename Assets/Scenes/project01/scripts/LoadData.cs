using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TextureData
{
    public TextureData(string _name, Texture2D _tex2d)
    {
        name = _name;
        texture2d = _tex2d;
    }

    public string name;
    public Texture2D texture2d;
}

public class LoadData : MonoBehaviour
{
    public static LoadData instace;

    public DropDownManager dropDownManager;
    public List<TextureData> allTextures = new List<TextureData>();

    private void Awake()
    {
        instace = this;
    }

    private void Start()
    {
        GetStreamingAssetsAllFiles();
        dropDownManager.Init();
    }

    private void GetStreamingAssetsAllFiles()
    {
        var info = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath, "textures"));
        var fileInfo = info.GetFiles();
        foreach (var file in fileInfo)
        {
            if (file.Extension.Equals(".png"))
            {
                byte[] pngBytes = File.ReadAllBytes(file.FullName);
                var textures = new Texture2D(2, 2);
                textures.LoadImage(pngBytes);
                
                string name = file.Name.Split(new char[] { '.' })[0];
                allTextures.Add(new TextureData(name, textures));
            }
        }
    }

}
