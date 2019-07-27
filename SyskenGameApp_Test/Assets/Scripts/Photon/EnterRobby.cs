using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class EnterRobby : MonoBehaviourPunCallbacks {

    string roomName = "";
    int roomCnt = 0;
    string searchRoomName = "room";
    SearchState state = SearchState.CreateRoom;

    enum SearchState {
        CreateRoom,
        JoinRoom
    }

    private void Start() {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    public void StartMatching() {
        CreateRoom();
    }
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
    }

    public void CreateRoom(){
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(searchRoomName + roomCnt, room, TypedLobby.Default);
    }

    public void SearchRoom() {
        PhotonNetwork.JoinRoom(searchRoomName + roomCnt);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Battle");
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        //var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        //PhotonNetwork.Instantiate("Player", v, Quaternion.identity);
    }

    //JoinRoomが失敗したときに呼ばれる
    void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
        //codeAndMsg[0]は エラーコード です。(int)
        //codeAndMsg[1]は デバッグメッセージ です。(string)
        if (roomCnt > 5 && state == SearchState.JoinRoom) {
            roomCnt = 0;
            Debug.Log("Failed Matching Try Again");
            return;
        }
        if (roomCnt > 5){
            Debug.Log("Search Room");
            roomCnt = 0;
            state = SearchState.JoinRoom;
        }
        roomCnt++;
        if (state == SearchState.CreateRoom) {
            CreateRoom();
        }else if (state == SearchState.JoinRoom) {
            SearchRoom();
        }
    }

    void OnPhotonCreateRoomFailed(object[] codeAndMsg) {
        //codeAndMsg[0]は エラーコード です。(int)
        //codeAndMsg[1]は デバッグメッセージ です。(string)
    }
}