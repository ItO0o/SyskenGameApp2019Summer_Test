using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionSelector : MonoBehaviour {
    string SAVE_FILE_PATH = "Save/SaveData.json";
    // Use this for initialization
    void Start () {
        try
        {
            GameObject.Find("Text").GetComponent<Text>().text = Application.dataPath + "/" + SAVE_FILE_PATH;
        var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
            LoginInfo data = JsonUtility.FromJson<LoginInfo>(json);
            StaticInfo.userInfo = data;
            SceneManager.LoadScene("Title");
        }
        catch
        {
            SceneManager.LoadScene("Login");
        }
    }
}
