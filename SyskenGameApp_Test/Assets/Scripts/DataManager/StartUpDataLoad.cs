using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpDataLoad : MonoBehaviour {
    public static bool firstLoad = true;
	// Use this for initialization
	void Start () {
        LoadData ld = new LoadData();
        ld.LoadUserInfo();
        ld.LoadInventory();
        if (firstLoad) {
            Instantiate(Resources.Load<GameObject>("GameSparks"));
            firstLoad = false;
        }
    }
}
