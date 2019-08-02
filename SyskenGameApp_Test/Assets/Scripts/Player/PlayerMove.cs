using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float speed, forwardAcceleration = 0, backAcceleration = 0, rate, forwardMaxSpeed, backMaxSpeed;
    private PhotonView m_photonView;
    void Start()
    {
        m_photonView = this.GetComponent<PhotonView>();
    }

//#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!m_photonView.IsMine)
        {
            return;
        }
        if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom)
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveBack();
            }
            else
            {
                this.backAcceleration = 0;
            }
            if (Input.GetKey(KeyCode.D))
            {
                MoveForward();
            }
            else
            {
                this.forwardAcceleration = 0;
            }
        }
        else if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom)
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveBack();
            }
            else
            {
                this.backAcceleration = 0;
            }
            if (Input.GetKey(KeyCode.A))
            {
                MoveForward();
            }
            else
            {
                this.forwardAcceleration = 0;
            }
        }
    }
//#endif

    void MoveForward()
    {
        if (this.forwardAcceleration < this.forwardMaxSpeed)
        {
            this.forwardAcceleration += rate;
        }
        this.transform.position += this.transform.right * this.speed * this.forwardAcceleration;
    }

    void MoveBack()
    {
        if (this.backAcceleration < this.backMaxSpeed)
        {
            this.backAcceleration += rate;
        }
        this.transform.position += -this.transform.right * this.speed * this.backAcceleration;
    }

    private void Move()
    {

    }
}
