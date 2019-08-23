using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine.UI;

public class TesTes : MonoBehaviour {
    private void Start() {
       GameObject instObj = Instantiate(Resources.Load<GameObject>("Part_Button"), new Vector3(GameObject.Find("Canvas").transform.position.x, GameObject.Find("Canvas").transform.position.y, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        instObj.AddComponent<ItemDetail>();
    }
    // Use this for initialization
    //void Start () {
    //       StaticInfo.userInfo.userName = "235211";
    //       StaticInfo.userInfo.passWord = "0000";
    //       //StaticInfo.userData.rate = 100;
    //       //StaticInfo.userData.gold = 2500;
    //       StaticInfo.items.Add(new Item { name = "Item1", cnt = 100 });
    //       StaticInfo.items.Add(new Item { name = "Item2", cnt = 0 });
    //       StaticInfo.items.Add(new Item { name = "Item3", cnt = 50 });
    //       SendData sd = new SendData();
    //       sd.SendInventoryData();
    //SendData sd = new SendData();
    //sd.SendUserInfo();
    //sd.SendInventoryData();
    //new LogEventRequest()
    // .SetEventKey("Get_Item_Drop")
    // .Send((response) => {
    //     if (!response.HasErrors) {
    //         GameSparks.Core.GSData scriptData = response.ScriptData.GetGSData("data");
    //         Debug.Log(scriptData.GetInt("name"));
    //     } else {
    //         Debug.Log("Error");
    //     }
    // });
//}
 
}
