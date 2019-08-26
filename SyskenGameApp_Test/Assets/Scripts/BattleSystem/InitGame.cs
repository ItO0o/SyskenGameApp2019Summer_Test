using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    bool tempReady;
    // Start is called before the first frame update
    void Awake()
    {
        StaticInfo.gameReady = false;
        Timer.time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempReady != StaticInfo.gameReady) {
            GameObject.Find("UI_Manager").AddComponent<HPSlider>();
            DestroyImmediate(this.gameObject);
        }
        tempReady = StaticInfo.gameReady;
    }
}
