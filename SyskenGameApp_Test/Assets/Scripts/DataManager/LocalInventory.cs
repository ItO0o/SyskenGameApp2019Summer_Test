using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LocalInventory : MonoBehaviour
{

    string CUSTOM_DATA_PATH = "Save/CustomData.json";

    private void Start() {
        Load();
        GameObject.Find("UI_Manager").GetComponent<ViewMyFuso>().UpdateView();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(new Serialization<string>(StaticInfo.myCustom));
        var path = Application.dataPath + "/" + CUSTOM_DATA_PATH;
        var writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }

    public void Load()
	{
        try {
            var info = new FileInfo(Application.dataPath + "/" + CUSTOM_DATA_PATH);
            var reader = new StreamReader(info.OpenRead());
            var json = reader.ReadToEnd();
            //var  temp = JsonUtility.FromJson<List<string>>(json);
            //var temp = new Serialization<List<string>>.ToList(json);
            StaticInfo.myCustom = JsonUtility.FromJson<Serialization<string>>(json).ToList();
            foreach (string s in JsonUtility.FromJson<Serialization<string>>(json).ToList()) {
                Debug.Log("Load custom parts:" + s);
            }
            reader.Close();
        } catch {
            Debug.Log("Error load custom item");
        }
    }
}
