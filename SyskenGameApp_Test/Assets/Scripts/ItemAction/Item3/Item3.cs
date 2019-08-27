using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item3 : MonoBehaviour {
    bool tempCheck = false;

    private void Start() {
        if (this.GetComponent<PhotonView>().IsMine == false && GameObject.Find("Kongo(Clone)") != null) {
            this.transform.parent = GameObject.Find("Kongo(Clone)").transform.Find("CustomParts").transform;
        }
    }

    // Update is called once per frame
    void Update() {
        if (this.GetComponent<CheckSetted>().setted == true && tempCheck == false) {
            this.transform.parent = GameObject.Find(StaticInfo.playerName).transform.Find("CustomParts");
        }
        if (this.transform.position.y < -10 && this.GetComponent<PhotonView>().IsMine) {
            this.GetComponent<CheckSetted>().outOfGanchu = true;
            PhotonNetwork.Destroy(this.gameObject);
        }
        tempCheck = this.GetComponent<CheckSetted>().setted;
    }
}
