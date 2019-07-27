using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PrintDebugLog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void Print()
    {
        Debug.Log(PhotonNetwork.CountOfRooms);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
