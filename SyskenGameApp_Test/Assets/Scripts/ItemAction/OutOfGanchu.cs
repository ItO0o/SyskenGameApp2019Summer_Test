﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OutOfGanchu : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.name.Equals("Water") && this.GetComponent<PhotonView>().IsMine) {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
