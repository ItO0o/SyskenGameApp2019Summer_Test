using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour {
    bool tempCheck = false;

    // Update is called once per frame
    void Update() {
        if (this.GetComponent<CheckSetted>().setted == true && tempCheck == false) {
            this.transform.parent = GameObject.Find(StaticInfo.playerName).transform.Find("CustomParts");
        }
        tempCheck = this.GetComponent<CheckSetted>().setted;
    }
}
