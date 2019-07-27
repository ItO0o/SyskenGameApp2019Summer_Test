using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTempInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StaticInfo.tempData.userName = StaticInfo.userInfo.dispName;
	}
}
