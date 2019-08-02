using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField]
    float speed, acceleration = 0, rate, forwardMaxSpeed, backMaxSpeed;
    


#if UNITY_EDITOR
    // Update is called once per frame
    void FixedUpdate() {
        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))) {
            acceleration = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
            acceleration = 0;
        }
        if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom) {
            if (Input.GetKey(KeyCode.A)) {
                MoveForward();
            }
            if (Input.GetKey(KeyCode.D)) {
                MoveBack();
            }
        }else if(ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
            if (Input.GetKey(KeyCode.D)) {
                MoveBack();
            }
            if (Input.GetKey(KeyCode.A)) {
                MoveForward();
            }
        }
    }
#endif
    // Use this for initialization
    void Start() {

    }

    void MoveForward() {
        if (acceleration < forwardMaxSpeed) {
            acceleration += rate;
            }
        this.transform.position += this.transform.right * speed * acceleration;
    }

    void MoveBack() {
        if (acceleration < backMaxSpeed) {
            acceleration += rate;
            }
        this.transform.position += -this.transform.right * speed * acceleration;
    }

    private void Move() {

    }
}
