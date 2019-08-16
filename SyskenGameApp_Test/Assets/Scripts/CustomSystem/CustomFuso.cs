using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFuso : MonoBehaviour
{
   public void AddParts(string partsName,int index) {
        if (StaticInfo.items[index].cnt > 0) {
            StaticInfo.myCustom.Add(partsName);
            StaticInfo.items[index].cnt--;
            GameObject.Find("UI_Manager").GetComponent<CustomPartsView>().UpdateItemCntView();
        }
    }
}
