using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonBattleManager : MonoBehaviourPunCallbacks
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Enter this room "+newPlayer.NickName);
        GameObject obj = Resources.Load<GameObject>("Fadeout_Text");
        GameObject instObj = Instantiate(obj);
        instObj.transform.parent = GameObject.Find("Canvas").transform;
        instObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
        instObj.GetComponent<Text>().text =newPlayer.NickName + "さんが参加しました";
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        GameObject.Find("Message_TextField").GetComponent<Text>().text = "相手がルームから退室しました";
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.Disconnect();
        GameObject.Find("UI_Manager").GetComponent<HideStart>().FindAndGetHideObj("Exit_Button").SetActive(true);
        Debug.Log("Opponent leave from room");
    }
}
