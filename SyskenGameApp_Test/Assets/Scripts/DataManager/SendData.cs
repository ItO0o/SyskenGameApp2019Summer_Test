using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

/// <summary>
/// Send data or info to GameSparks.
/// </summary>
public class SendData : MonoBehaviour {

    /// <summary>
    /// Sends the user info.
    /// </summary>
    /// <returns><c>true</c>, if user info was sent, <c>false</c> otherwise.</returns>
    public void SendUserInfo() {
        //とりあえず保存先ユーザー指定,認証
        new AuthenticationRequest()
       .SetPassword("0000")
       .SetUserName(StaticInfo.userInfo.userName)
               .Send((response) => {
                   if (!response.HasErrors) {
                       Debug.Log("Authentication successfully");
                   } else {
                       Debug.Log("Error authentication");
                   }
               });

        //プレイヤーデータ整形
        PlayerData player = new PlayerData {
            gold = StaticInfo.userData.gold,
            rate = StaticInfo.userData.rate
        };
        //jsonに変換
        string jsonData = JsonUtility.ToJson(player);
        GameSparks.Core.GSRequestData data = new GameSparks.Core.GSRequestData(jsonData);
        //送信イベントリクエスト
        new LogEventRequest()
                .SetEventKey("SavePlayerData")
                .SetEventAttribute("playerData", data)
                .Send((response) => {
                    if (!response.HasErrors) {
                        Debug.Log("Save data successfully");
                    } else {
                        Debug.Log("Error save player data");
                    }
                });
    }

    /// <summary>
    /// Sends the inventory data.
    /// </summary>
    /// <returns><c>true</c>, if inventory data was sent, <c>false</c> otherwise.</returns>
    public void SendInventoryData() {
        new AuthenticationRequest()
            .SetPassword("0000")
            .SetUserName(StaticInfo.userInfo.userName)
            .Send((response) => {
            if (!response.HasErrors) {
                Debug.Log("Login successfully");
            } else {
                Debug.Log("Error login");
            }
        });
        //データ整形（シリアライズ込み）
        string jsonData = JsonUtility.ToJson(new Serialization<Item>(StaticInfo.items));
        GameSparks.Core.GSRequestData data = new GameSparks.Core.GSRequestData(jsonData);
        //送信リクエスト
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
    }
}
