using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Item1 : MonoBehaviour {
    GameObject instObj;
    public float timeOut = 5;
    private float timeElapsed;
    bool tempCheck;
    private void Start() {
        if (this.GetComponent<PhotonView>().IsMine == false && GameObject.Find("Kongo(Clone)") != null) {
            this.transform.parent = GameObject.Find("Kongo(Clone)").transform.Find("CustomParts").transform;
        }
        this.transform.localScale = new Vector3(this.transform.localScale.x,this.transform.localScale.y,this.transform.localScale.z);
        //this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y  + 180, this.transform.rotation.z, this.transform.rotation.w);
    }

    private void Update() {
        if (this.GetComponent<CheckSetted>().setted == true && tempCheck == false) {
            this.transform.parent = GameObject.Find(StaticInfo.playerName).transform.Find("CustomParts");
        }
        if (this.GetComponent<PhotonView>().IsMine == false || this.GetComponent<CheckSetted>().setted == false) {
            return;
        }
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut) {
            timeElapsed = 0.0f;

            instObj = PhotonNetwork.Instantiate("Bullet_01", this.transform.position + (this.transform.right * 2), Quaternion.identity);
            
            if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
                instObj.GetComponent<Rigidbody2D>().AddForce(new Vector3(this.transform.transform.right.x * 500, this.transform.transform.right.y * 200, 0));
            }
            if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom) {
                instObj.GetComponent<Rigidbody2D>().AddForce(new Vector3(this.transform.transform.right.x * 500, this.transform.transform.right.y * 200, 0));
            }
        }
        if (this.transform.position.y < -10 && this.GetComponent<PhotonView>().IsMine) {
            this.GetComponent<CheckSetted>().outOfGanchu = true;
            PhotonNetwork.Destroy(this.gameObject);
        }
        tempCheck = this.GetComponent<CheckSetted>().setted;
    }
    //private void LateUpdate() {
    //    if (GetComponent<PhotonView>().IsMine) {
    //        //this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.y, this.transform.rotation.w);
    //    }
    //}
}
