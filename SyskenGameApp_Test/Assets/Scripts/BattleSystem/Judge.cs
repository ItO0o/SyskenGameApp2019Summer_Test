using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviourPunCallbacks {
    GameObject myShip;
    public bool gameStart = false;
    public GameObject enemy;
    int tempHp;
    // Start is called before the first frame update
    void Start() {
        gameStart = false;
        myShip = GameObject.Find(StaticInfo.playerName);
        //enemy = GameObject.Find("Kongo(Clone)");
    }

    // Update is called once per frame
    void Update() {
        if (enemy == null) {
            enemy = GameObject.Find("Kongo(Clone)");
        }
        if (tempHp != myShip.GetComponent<PlayerBattleStatus>().hp) {
            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
                //Debug.Log(myShip.GetComponent<PlayerBattleStatus>().hp);
                hashtable["CreateHP"] = myShip.GetComponent<PlayerBattleStatus>().hp.ToString();
            } else {
                hashtable["JoinHP"] = myShip.GetComponent<PlayerBattleStatus>().hp.ToString();
            }
            PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
        }
        if ((gameStart || ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom)) {
            if (myShip.GetComponent<PlayerBattleStatus>().hp <= 0) {
                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
                    hashtable["Judge"] = ConnectionPhoton.SearchState.JoinRoom.ToString();
                } else if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.JoinRoom) {
                    hashtable["Judge"] = ConnectionPhoton.SearchState.CreateRoom.ToString();
                }
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
            }

            if (Timer.time > 120) {
                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                hashtable["Judge"] = "TimeOver";
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);
            }
        }
        tempHp = myShip.GetComponent<PlayerBattleStatus>().hp;
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged) {
        if (propertiesThatChanged.TryGetValue("Judge", out object value)) {
            if (value.ToString().Equals(ConnectionPhoton.searchState.ToString())) {
                StaticInfo.win = true;
            } else if (value.ToString().Equals("TimeOver")) {
                SceneManager.LoadScene("TimeOver");
                PhotonNetwork.LeaveRoom();
                return;
            } else {
                StaticInfo.win = false;
            }
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Result");
        }
        try {
            if (ConnectionPhoton.searchState == ConnectionPhoton.SearchState.CreateRoom) {
                if (propertiesThatChanged.TryGetValue("JoinHP", out object value2)) {
                    enemy.GetComponent<PlayerBattleStatus>().hp = int.Parse(value2.ToString());
                }
            } else {
                if (propertiesThatChanged.TryGetValue("CreateHP", out object value2)) {
                    enemy.GetComponent<PlayerBattleStatus>().hp = int.Parse(value2.ToString());
                }
            }
        } catch {

        }
    }
}
