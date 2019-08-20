using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviourPunCallbacks {
    GameObject myShip;
    public bool gameStart = false;
    // Start is called before the first frame update
    void Start() {
        gameStart = false;
        myShip = GameObject.Find(StaticInfo.playerName);
    }

    // Update is called once per frame
    void Update() {
        if ((gameStart || ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom)) {
            if (myShip.GetComponent<PlayerBattleStatus>().hp <= 0) {
                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
                    hashtable["Judge"] = ConnectionPhoton.SearchState.JoinRoom.ToString();
                } else {
                    hashtable["Judge"] = ConnectionPhoton.SearchState.CreateRoom.ToString();
                }
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
            }
        }
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged) {
        if (propertiesThatChanged.TryGetValue("Judge", out object value)) {
            if (value.ToString().Equals(ConnectionPhoton.searchState.ToString())) {
                StaticInfo.win = true;
            } else {
                StaticInfo.win = false;
            }
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Result");
        }
    }

}
