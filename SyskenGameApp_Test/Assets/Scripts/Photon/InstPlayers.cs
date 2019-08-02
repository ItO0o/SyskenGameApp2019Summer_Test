using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class InstPlayers : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom)
        {
            PhotonNetwork.Instantiate("Kongo", new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }else if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom)
        {
            PhotonNetwork.Instantiate("Kongo", new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
