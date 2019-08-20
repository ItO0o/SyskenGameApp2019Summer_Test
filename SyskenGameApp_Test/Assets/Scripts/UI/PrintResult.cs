using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PrintResult : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        if (StaticInfo.win) { 
            this.GetComponent<Text>().text = "勝ちました";
        } else {
            this.GetComponent<Text>().text = "負けました";
        }
    }
}
