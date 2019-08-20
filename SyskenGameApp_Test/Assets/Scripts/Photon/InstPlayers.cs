using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class InstPlayers : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GameObject instObj;
        if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom)
        {
            instObj = PhotonNetwork.Instantiate("Kongo", new Vector3(-10, 0, 0), new Quaternion(0, 0, 0, 0));
            instObj.name = "Player2";
            StaticInfo.playerName = instObj.name;
        } else if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom)
        {
            instObj = PhotonNetwork.Instantiate("Kongo", new Vector3(10, 0, 0), new Quaternion(0, 180, 0, 0));
            instObj.name = "Player1";
            StaticInfo.playerName = instObj.name;
        }
        
	}
	
}
