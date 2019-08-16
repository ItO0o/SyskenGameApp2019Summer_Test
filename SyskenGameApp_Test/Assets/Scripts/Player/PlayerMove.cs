﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviour {
    [SerializeField]
    float forwardMaxSpeed, backMaxSpeed, acceleration, forwardAcceleration, backAcceleration, brakePower;
    //[SerializeField]
    //float speed, forwardAcceleration = 0, backAcceleration = 0, rate, forwardMaxSpeed, backMaxSpeed;
    private PhotonView m_photonView;
    void Start() {
        m_photonView = this.GetComponent<PhotonView>();
       
    }

    //#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    // Update is called once per frame
    void FixedUpdate() {
        Move();
    }
    //#endif

    private void Move() {
        if (!m_photonView.IsMine) {
            return;
        }
        Debug.Log(ConnectionPhoton.searchState);
        if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
            if (Input.GetKey(KeyCode.D) && acceleration >  -backMaxSpeed) {
                this.acceleration -= backAcceleration;
            }
            if (Input.GetKey(KeyCode.A) && acceleration < forwardMaxSpeed) {
                this.acceleration += forwardAcceleration;
            }
        } else {
            if (Input.GetKey(KeyCode.D) && acceleration < forwardMaxSpeed) {
                this.acceleration += forwardAcceleration;
            }
            if (Input.GetKey(KeyCode.A) && acceleration > -backMaxSpeed) {
                this.acceleration -= backAcceleration;
            }
        }

        if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false) {
            if (acceleration > 0.002f) {
                this.acceleration -= brakePower;
            } else if (acceleration < -0.002f) {
                this.acceleration += brakePower;
            } else {
                this.acceleration = 0;
            }
        }

        this.transform.position += this.transform.right * this.acceleration;
    }
}
