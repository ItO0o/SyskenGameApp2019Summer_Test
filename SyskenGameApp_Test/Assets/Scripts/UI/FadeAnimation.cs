using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimation : MonoBehaviour {
    float a = 1;
	// Update is called once per frame
	void FixedUpdate () {
        this.GetComponent<Text>().color = new Color(0,0,0,a);
        a -= 0.01f;
        if (a <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
