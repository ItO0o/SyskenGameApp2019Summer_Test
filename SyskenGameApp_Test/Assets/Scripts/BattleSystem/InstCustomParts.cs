using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InstCustomParts : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        GameObject player = GameObject.Find(StaticInfo.playerName);
        LocalInventory li = new LocalInventory();
        li.Load();
        float y = 0;
        foreach (string s in StaticInfo.myCustom) {
            GameObject instParts = PhotonNetwork.Instantiate(s, new Vector3(player.transform.position.x, player.transform.position.y + y, 0), new Quaternion(0, 180, 0, 0));
            instParts.transform.parent = player.transform.Find("CustomParts").transform;
            y++;
        }
    }
}
