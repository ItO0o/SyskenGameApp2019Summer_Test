using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class BulletAction : MonoBehaviour {
    [SerializeField]
    int atk = 5;
    public float timeOut = 3;
    private float timeElapsed;
    GameObject myShip;
    private void Start() {
        myShip = GameObject.Find(StaticInfo.playerName);
        Instantiate(Resources.Load("FireSmork"),new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z),Quaternion.identity);
    }

    private void Update() {
        if (this.GetComponent<PhotonView>().IsMine == false) {
            return;
        }
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut) {
            timeElapsed = 0.0f;
            PhotonNetwork.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Equals("Kongo(Clone)")||collision.gameObject.name.Equals(StaticInfo.playerName)) { 
            if (this.GetComponent<PhotonView>().IsMine && !collision.gameObject.GetComponent<PhotonView>().IsMine) {
                collision.gameObject.GetComponent<PlayerBattleStatus>().hp -= atk;
            }
            if (!this.GetComponent<PhotonView>().IsMine && collision.gameObject.GetComponent<PhotonView>().IsMine) {
                myShip.GetComponent<PlayerBattleStatus>().hp -= atk;
            }

            Instantiate<GameObject>(Resources.Load<GameObject>("Explosion"),this.transform.position,Quaternion.identity);
        }

        if (collision.transform.name.Contains("Item1") == false && this.GetComponent<PhotonView>().IsMine) {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }

    private void LateUpdate() {
        if (GetComponent<PhotonView>().IsMine) {
            this.transform.rotation = new Quaternion(0, 0, this.transform.rotation.z, 0);
        }
    }
}
