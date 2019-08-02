using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class FirstAuthentication : MonoBehaviour {

    string displayName = "";
    string password = "";
    string userName = "";
    bool? newPlayer = true;
    string userId = "";

    public static string authToken = "";

    InputField inputField;
    Text warningText;

    string SAVE_FILE_PATH = "Save/SaveData.json";

    void Awake() {
        inputField = GameObject.Find("Name_TextField").GetComponent<InputField>();
        warningText = GameObject.Find("Warning_Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void RegistrationRequest() {
        if (inputField.text.Length > 0) {
            warningText.text = "";
            displayName = UnityEngine.Random.Range(0, 1000000).GetHashCode().ToString();
            userName = UnityEngine.Random.Range(0, 1000000).GetHashCode().ToString();
            password = "0000";
        } else {
            warningText.text = "Please Input Name";
            return;
        }

        new RegistrationRequest()
          .SetDisplayName(displayName)
          .SetPassword(password)
          .SetUserName(userName)
          .Send((response) => {
            authToken = response.AuthToken;
            newPlayer = response.NewPlayer;
            RegistrationResponse._Player switchSummary = response.SwitchSummary;
            userId = response.UserId;
      });

        if (newPlayer.Value == false) {
            RegistrationRequest();
        } else {
            StaticInfo.userInfo.dispName = this.inputField.text;
            StaticInfo.userInfo.first = false;
            StaticInfo.userInfo.passWord = this.password;
            StaticInfo.userInfo.userName = this.userName;

            var json = JsonUtility.ToJson(StaticInfo.userInfo);
            var path = Application.dataPath + "/" + SAVE_FILE_PATH;
            var writer = new StreamWriter(path, false);
            Debug.Log(json);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();

            Debug.Log("New Player:" + userId.ToString());

            SceneManager.LoadScene("Title");
        }
    }
}
