using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetEnemyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (StaticInfo.win == true) {
            GameObject enemy = GameObject.Find("Kongo(Clone)");
            for (int i = 0; i < StaticInfo.enemyCustom.Count; i++) {
                Debug.Log(StaticInfo.enemyCustom[i]);
            }
            GameObject.Find("Result_Text").GetComponent<Text>().text = "勝利しました" +
               "\n<戦利品>\n";
            for (int i = 0; i < (120 - Timer.time) / 10; i++) {
              int rand = Random.Range(0,StaticInfo.enemyCustom.Count - 1);
                GameObject.Find("Result_Text").GetComponent<Text>().text = GameObject.Find("Result_Text").GetComponent<Text>().text + StaticInfo.enemyCustom[rand].ToString() + "\n";
                StaticInfo.items[StaticInfo.items.FindIndex(0, n => n.name.Equals(StaticInfo.enemyCustom[rand]))].cnt ++;
            }
            SendData sd = new SendData();
            sd.SendInventoryData();
        } else {
            GameObject.Find("Result_Text").GetComponent<Text>().text = "敗北しました";
            StaticInfo.myCustom = new List<string>();
            LocalInventory li = new LocalInventory();
            li.Save();
            StaticInfo.items = new List<Item>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
