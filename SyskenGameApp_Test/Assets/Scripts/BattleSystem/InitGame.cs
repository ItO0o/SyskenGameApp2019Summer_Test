using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour {
    bool tempReady;
    // Start is called before the first frame update
    void Awake() {
        StaticInfo.gameReady = false;
        Timer.time = 0;
        StaticInfo.enemyCustom = new List<string>();
    }

    // Update is called once per frame
    void Update() {
        if (tempReady != StaticInfo.gameReady) {
            GameObject.Find("UI_Manager").AddComponent<HPSlider>();
            GameObject enemy = GameObject.Find("Kongo(Clone)");

            for (int i = 0; i < enemy.transform.GetChild(0).childCount; i++) {
                StaticInfo.enemyCustom.Add(enemy.transform.GetChild(0).GetChild(i).name.Split('(')[0]);
            }
            DestroyImmediate(this.gameObject);
        }
        tempReady = StaticInfo.gameReady;
    }
}
