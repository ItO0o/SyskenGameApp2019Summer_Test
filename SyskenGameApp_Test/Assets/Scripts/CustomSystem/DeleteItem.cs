using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    public void Delete() {
        try {
            if (StaticInfo.myCustom != null) {
                StaticInfo.myCustom.RemoveAt(StaticInfo.myCustom.Count - 1);
                //Debug.Log(StaticInfo.items.Find(n => n.name == StaticInfo.myCustom[StaticInfo.myCustom.Count - 1]).name);
                StaticInfo.items.Find(n => n.name == StaticInfo.myCustom[StaticInfo.myCustom.Count - 1]).cnt++;
                GameObject.Find("UI_Manager").GetComponent<CustomPartsView>().UpdateItemCntView();
            }
        } catch {
            Debug.Log("Any item attached");
        }
    }
}
