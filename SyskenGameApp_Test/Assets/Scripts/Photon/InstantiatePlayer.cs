using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
