using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

/// <summary>
/// Load data or info to GameSparks.
/// </summary>
public class LoadData : MonoBehaviour {
    //エラーチェック用
    private bool check;

    /// <summary>
    /// ユーザーデータをGameSparkより引き出してStaticフィールドに反映します
    /// </summary>
    /// <returns><c>true</c>, ロード成功, <c>false</c> ロード失敗.</returns>
    public bool LoadUserInfo() {
        check = true;
        //とりあえず保存先ユーザー指定,認証
        new AuthenticationRequest()
        .SetPassword("0000")
        .SetUserName(StaticInfo.userInfo.userName)
        .Send((response) => {
            if (!response.HasErrors) {
                Debug.Log("Login successfully");
            } else {
                Debug.Log("Error login");
                check = false;
            }
        });
        //イベントリクエスト
        new LogEventRequest()
         .SetEventKey("LoadPlayerData")
         .Send((response) => {
             if (!response.HasErrors) {
                 GameSparks.Core.GSData scriptData = response.ScriptData.GetGSData("data");
                 PlayerData playerData = new PlayerData {
                     rate = (int)scriptData.GetInt("rate"),
                     gold = (int)scriptData.GetInt("gold")
                 };
                 //スタティックフィールドに反映
                 StaticInfo.userData.rate = playerData.rate;
                 StaticInfo.userData.gold = playerData.gold;
                 Debug.Log("Load user data (rate:" + playerData.rate + "gold:" + playerData.gold + ")");
             } else {
                 Debug.Log("Error Load Player Data");
                 check = false;
             }
         });

        if (check == false) {
            return false;
        } else {
            return true;
        }
    }

    /// <summary>
    /// Loads the inventory.
    /// </summary>
    /// <returns><c>true</c>, if inventory was loaded, <c>false</c> otherwise.</returns>
    public bool LoadInventory() {
        check = true;
        //イベントリクエスト
        new LogEventRequest()
          .SetEventKey("LoadInventory")
          .Send((response) => {
              if (!response.HasErrors) {
                  GameSparks.Core.GSData scriptData = response.ScriptData.GetGSData("data");
                  var temp = scriptData.GetGSDataList("target");

                  //受信データを整形、スタティックフィールドに反映
                  for (int i = 0; i < temp.Count; i++) {
                      Item tempItem = new Item {
                          name = temp[i].GetString("name"),
                          cnt = (int)temp[i].GetInt("cnt")
                      };
                      StaticInfo.items.Add(tempItem);
                  }

                  foreach (Item tempItem in StaticInfo.items) {
                      Debug.Log("Load inventory　(name:" + tempItem.name + "cnt:" + tempItem.cnt+")");
                  }
              } else {
                  Debug.Log("Error Load Player Data");
                  check = false;
              }
          });

        if (check == false) {
            return false;
        } else {
            return true;
        }
    }
}
