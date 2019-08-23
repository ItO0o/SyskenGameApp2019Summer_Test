using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item1 : MonoBehaviour {
    GameObject instObj;
    public float timeOut = 5;
    private float timeElapsed;

    private void Update() {

        if (this.GetComponent<PhotonView>().IsMine == false) {
            return;
        }
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut) {
            timeElapsed = 0.0f;

            instObj = PhotonNetwork.Instantiate("Bullet_01", this.transform.position, Quaternion.identity);
            //instObj.transform.parent = this.transform;
            if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
                instObj.GetComponent<Rigidbody2D>().AddForce(new Vector3(this.transform.transform.right.x * 500, 200, 0));
            }
            if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom) {
                instObj.GetComponent<Rigidbody2D>().AddForce(new Vector3(-this.transform.transform.right.x * 500, 200, 0));
            }
        }
        if (this.transform.position.y < -10) {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
    private void LateUpdate() {
        if (GetComponent<PhotonView>().IsMine) {
            this.transform.rotation = new Quaternion(0, 0, this.transform.rotation.z, 0);
        }
    }
}
