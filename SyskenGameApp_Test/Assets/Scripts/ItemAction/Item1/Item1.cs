using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item1 : MonoBehaviour
{
    GameObject instObj;

    private void Update() {
        if (Input.GetMouseButtonDown(0) && this.GetComponent<PhotonView>().IsMine) {
            instObj = PhotonNetwork.Instantiate("Bullet_01", this.transform.position,Quaternion.identity);
            instObj.transform.parent = this.transform;
            instObj.GetComponent<Rigidbody2D>().AddForce(new Vector3(this.transform.parent.transform.right.x * 500,200,0));
        }
    }
}
