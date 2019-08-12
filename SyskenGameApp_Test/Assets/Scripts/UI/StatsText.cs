using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GameObject text = GameObject.Find("Stats_Text");
	}
    public static void FixedUpdate()
    {
        StaticInfo.callback = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (StaticInfo.callback.Equals("Loaded data"))
        {
            this.GetComponent<Text>().text = "Your Stats(Rate:" + StaticInfo.userData.rate + "Gold:" + StaticInfo.userData.gold + ")";
        }
	}
}
