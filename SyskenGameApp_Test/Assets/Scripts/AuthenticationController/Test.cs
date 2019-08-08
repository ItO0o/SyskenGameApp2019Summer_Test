using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class Test : MonoBehaviour {

    // Use this for initialization
    void Start() {
        //new AuthenticationRequest()
            //.SetPassword("0000")
            //.SetUserName("635472")
                    //.Send((response) => {
                    //    if (!response.HasErrors) {
                    //        Debug.Log("Login successfully");
                    //    } else {
                    //        Debug.Log("Error Login");
                    //    }
                    //});




        //Item item = new Item { name = "test1", cnt = 1 };
        //Item item2 = new Item { name = "test2", cnt = 3 };
        //StaticInfo.userData.items = item;        
        //Debug.Log(StaticInfo.userData.items.name);
        //StaticInfo.userData.items.Add(item2);
        Debug.Log("Saving");
        PlayerData player = new PlayerData {
            gold = 0,
            rate = 0
        };
        string jsonData = JsonUtility.ToJson(player);
        GameSparks.Core.GSRequestData data = new GameSparks.Core.GSRequestData(jsonData);

        new LogEventRequest()
            .SetEventKey("SavePlayerData")
            .SetEventAttribute("playerData", data)
            .Send((response) => {
                if (!response.HasErrors) {
                    Debug.Log("Save data successfully");
                } else {
                    Debug.Log("Error Saving Data");
                }
            });
    }

    // Update is called once per frame
    void Update() {

    }
}
