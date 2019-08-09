using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class Test : MonoBehaviour {

    // Use this for initialization
    void Start() {
        inventory();
        //playerdata();
    }

    void inventory() {
        new AuthenticationRequest()
.SetPassword("0000")
.SetUserName("334870")
     .Send((response) => {
         if (!response.HasErrors) {
             Debug.Log("Login successfully");
         } else {
             Debug.Log("Error login");
         }
     });

        Item item = new Item { name = "test1", cnt = 1 };
        Item item2 = new Item { name = "test2", cnt = 3 };
        //Debug.Log(StaticInfo.userData.items.name);
        StaticInfo.items.Add(item);
        StaticInfo.items.Add(item2);
        string jsonData = JsonUtility.ToJson(new Serialization<Item>(StaticInfo.items));
        //string jsonData = JsonUtility.ToJson(items);
        GameSparks.Core.GSRequestData data = new GameSparks.Core.GSRequestData(jsonData);
        Debug.Log(jsonData);
        new LogEventRequest()
        .SetEventKey("SaveInventory")
        .SetEventAttribute("inventory", data)
        .Send((response) => {
            if (!response.HasErrors) {
                Debug.Log("Save inventory successfully");
            } else {
                Debug.Log("Error save inventory");
            }
        });

        new LogEventRequest()
    .SetEventKey("LoadInventory")
    .Send((response) => {
        if (!response.HasErrors) {
            GameSparks.Core.GSData scriptData = response.ScriptData.GetGSData("data");
            var temp = scriptData.GetGSDataList("target");

            List<Item> items = new List<Item>();
            for (int i = 0;i < temp.Count;i++) {
                Item tempItem = new Item {
                    name = temp[i].GetString("name"),
                    cnt = (int)temp[i].GetInt("cnt")
                };
                StaticInfo.items.Add(tempItem);
            }

            foreach(Item tempItem in StaticInfo.items) {
                Debug.Log("name:" + tempItem.name + "cnt:" + tempItem.cnt);
            }
        } else {
            Debug.Log("Error Load Player Data");
        }
    });
    }


    void playerdata() {
        new AuthenticationRequest()
    .SetPassword("0000")
    .SetUserName("26337")
            .Send((response) => {
                if (!response.HasErrors) {
                    Debug.Log("Login successfully");
                } else {
                    Debug.Log("Error login");
                }
            });

        //Item item = new Item { name = "test1", cnt = 1 };
        //Item item2 = new Item { name = "test2", cnt = 3 };
        //StaticInfo.userData.items = item;        
        //Debug.Log(StaticInfo.userData.items.name);
        //StaticInfo.userData.items.Add(item2);
        Debug.Log("Saving");
        PlayerData player = new PlayerData {
            gold = 2,
            rate = 0
        };
        string jsonData = JsonUtility.ToJson(player);
        GameSparks.Core.GSRequestData data = new GameSparks.Core.GSRequestData(jsonData);
        Debug.Log(jsonData);
        new LogEventRequest()
                .SetEventKey("SavePlayerData")
                .SetEventAttribute("playerData", data)
                .Send((response) => {
                    if (!response.HasErrors) {
                        Debug.Log("Save data successfully");
                    } else {
                        Debug.Log("Error Save Player Data");
                    }
                });

        new LogEventRequest()
            .SetEventKey("LoadPlayerData")
            .Send((response) => {
                if (!response.HasErrors) {
                    GameSparks.Core.GSData scriptData = response.ScriptData.GetGSData("data");
                    PlayerData playerData = new PlayerData {
                        rate = (int)scriptData.GetInt("rate"),
                        gold = (int)scriptData.GetInt("gold")
                    };
                    Debug.Log("rate:" + playerData.rate + "gold:" + playerData.gold);
                } else {
                    Debug.Log("Error Load Player Data");
                }
            });
    }
}
