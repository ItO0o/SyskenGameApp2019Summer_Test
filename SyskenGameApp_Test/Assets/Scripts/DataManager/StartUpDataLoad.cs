using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpDataLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadData ld = new LoadData();
        ld.LoadUserInfo();
        ld.LoadInventory();
    }
}
