using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class TransitionSelector : MonoBehaviour {
    string SAVE_FILE_PATH = "Save/SaveData.json";
    // Use this for initialization
    void Start () {
        var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        LoginInfo data = JsonUtility.FromJson<LoginInfo>(json);
        if (StaticInfo.userInfo.first == true) {
            SceneManager.LoadScene("Login");
        } else {
            SceneManager.LoadScene("Title");
        }
    }
}
