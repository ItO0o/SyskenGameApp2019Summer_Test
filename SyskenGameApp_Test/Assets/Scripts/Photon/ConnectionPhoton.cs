using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class ConnectionPhoton : MonoBehaviourPunCallbacks {

    string roomName = "";
    int roomCnt = 1;
    string searchRoomName = "room";
    public static SearchState searchState = SearchState.JoinRoom;

    public enum SearchState {
        CreateRoom,
        JoinRoom
    }

    private void Start() {
        roomName = "";
        roomCnt = 1;
        searchRoomName = "room";
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        searchState = SearchState.JoinRoom;
        PhotonNetwork.NickName = StaticInfo.userInfo.dispName;
        if (PhotonNetwork.IsConnected) {
            SearchRoom();
        } else {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
        Debug.Log("Join Master");
        SearchRoom();
    }

    public void CreateRoom(){
        Debug.Log("Create room No." + roomCnt);
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 2;
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("Judge", "Non");
        room.CustomRoomProperties = customProp;
        PhotonNetwork.CreateRoom(searchRoomName + roomCnt, room, TypedLobby.Default);
        searchState = SearchState.CreateRoom;
    }

    public void SearchRoom() {
        Debug.Log("Search room No." + roomCnt);
        PhotonNetwork.JoinRoom(searchRoomName + roomCnt);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom() {
        Debug.Log("Joined room No." + roomCnt);
        PhotonNetwork.LoadLevel("Battle");
    }
    public override void OnCreateRoomFailed(short returnCode, string message) {
        Debug.Log("Failed Create room No." + roomCnt);
    }
    //JoinRoomが失敗したときに呼ばれる
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed join No." + roomCnt);
        if (roomCnt > PhotonNetwork.CountOfRooms)
        {
            roomCnt = PhotonNetwork.CountOfRooms + 1;
            CreateRoom();
        }
        if (searchState == SearchState.JoinRoom)
        {
            roomCnt++;
            SearchRoom();
        }
    }
}