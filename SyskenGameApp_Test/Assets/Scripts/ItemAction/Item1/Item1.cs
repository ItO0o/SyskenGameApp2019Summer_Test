using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item1 : MonoBehaviour
{
    GameObject instObj;
    public float timeOut = 5;
    private float timeTrigger;

    private void Update() {
        if (Time.time > timeTrigger) {
            instObj = PhotonNetwork.Instantiate("Bullet_01", this.transform.position,Quaternion.identity);
            instObj.transform.parent = this.transform;
            instObj.GetComponent<Rigidbody2D>().AddForce(new Vector3(this.transform.parent.transform.right.x * 500,200,0));
            timeTrigger = Time.time + timeOut;
        }
    }
}
