using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time = 0;
    public int timeInt;
    private Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticInfo.gameReady) {
            time += Time.deltaTime;
        }
        PrintTime();
    }

    void PrintTime() {
        timeText.text = ((int)time).ToString();
    }
}
