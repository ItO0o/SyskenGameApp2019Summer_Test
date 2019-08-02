using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class ConnectionPhoton : MonoBehaviourPunCallbacks {

    string roomName = "";
    int roomCnt = 0;
    string searchRoomName = "room";
    public static SearchState searchState = SearchState.CreateRoom;

    public enum SearchState {
        CreateRoom,
        JoinRoom
    }

    private void Start() {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
        Debug.Log("Join Master");
        SearchRoom();
    }

    public void CreateRoom(){
        Debug.Log("Create room No." + roomCnt);
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(searchRoomName + roomCnt, room, TypedLobby.Default);
    }

    public void SearchRoom() {
        Debug.Log("Search room No." + roomCnt);
        PhotonNetwork.JoinRoom(searchRoomName + roomCnt);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Battle");
    }

    //JoinRoomが失敗したときに呼ばれる
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed join No." + roomCnt);
        roomCnt++;
        if (roomCnt > PhotonNetwork.CountOfRooms)
        {
            searchState = SearchState.CreateRoom;
            roomCnt = 0;
            CreateRoom();
        }
        if (searchState == SearchState.JoinRoom)
        {
            SearchRoom();
        }
    }

    void OnPhotonCreateRoomFailed(object[] codeAndMsg) {
        //codeAndMsg[0]は エラーコード です。(int)
        //codeAndMsg[1]は デバッグメッセージ です。(string)
    }
}