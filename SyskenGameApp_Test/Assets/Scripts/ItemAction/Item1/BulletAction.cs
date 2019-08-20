using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class BulletAction : MonoBehaviour {
    [SerializeField]
    int atk = 5;

    GameObject myShip;
    private void Start() {
        myShip = GameObject.Find(StaticInfo.playerName);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PhotonView>() != null) {
            if (this.GetComponent<PhotonView>().IsMine && !collision.GetComponent<PhotonView>().IsMine) {
                collision.GetComponent<PlayerBattleStatus>().hp -= atk;
            }
            if (!this.GetComponent<PhotonView>().IsMine && collision.GetComponent<PhotonView>().IsMine) {
                myShip.GetComponent<PlayerBattleStatus>().hp -= atk;
            }
        }
    }

}
