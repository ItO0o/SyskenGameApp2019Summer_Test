using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks;

public class SendData : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //new LogEventRequest().SetEventKey("SAVE_PLAYER").SetEventAttribute("ITEM_TEST",1).SetEventAttribute("GOLD", 123456).Send((response) =>
        //{
        //    if (!response.HasErrors)
        //    {
        //        Debug.Log("Player Saved To GameSparks...");
        //    }
        //    else
        //    {
        //        Debug.Log("Error Saving Player Data...");
        //    }
        //});
        new LogEventRequest().SetEventKey("LOAD_DATA").Send((response) =>
        {
            if (!response.HasErrors)
            {
                var data = response.ScriptData.GetGSData("player_Data");
                Debug.Log("Received Player Data From GameSparks...");
                Debug.Log("Test Item Count: " + data.GetInt("Item_Test"));
                Debug.Log("Gold Count: " + data.GetInt("Gold"));
                StaticInfo.tempData.item_Test = (int)data.GetInt("Item_Test");
                StaticInfo.tempData.gold = (int)data.GetInt("Gold");
            }
            else
            {
                Debug.Log("Error Loading Player Data...");
            }
        });
    }

// Update is called once per frame
void Update()
{

}
}
