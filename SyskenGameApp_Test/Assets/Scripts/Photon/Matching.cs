using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class Matching : MonoBehaviourPunCallbacks
{

    string roomName = "";
    int roomCnt = 1;
    int maxSearchRoomCnt;
    string searchRoomName = "room";
    SearchState state = SearchState.JoinRoom;
    RoomOptions room = new RoomOptions();
    string joinedRoomName;

    //遷移状態
    enum SearchState
    {
        CreateRoom,
        JoinRoom
    }

    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        //StartMatching();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        //ロビーに接続
        //部屋数を所得
        maxSearchRoomCnt = PhotonNetwork.CountOfRooms;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnJoinedLobby()
    {
        //サーバー準備ができたらマッチング開始
            SearchRoom();
    }

    public void CreateRoom()
    {
        Debug.Log("Creating Room with " + searchRoomName + (PhotonNetwork.CountOfRooms + 1));
        // カウントの最後尾に部屋を追加
        room.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(searchRoomName + (PhotonNetwork.CountOfRooms + 1), room, TypedLobby.Default);
    }

    public void SearchRoom()
    {
        Debug.Log("Search Room with " + searchRoomName + roomCnt);
        PhotonNetwork.JoinRoom(searchRoomName + roomCnt);
    }

    public override void OnCreatedRoom()
    {
        RoomInfo info = PhotonNetwork.CurrentRoom;
        Debug.Log("Created Room with Named " + info.Name);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        RoomInfo info = PhotonNetwork.CurrentRoom;
        Debug.Log("Join to " + info.Name);
        PhotonNetwork.LoadLevel("Battle");
    }

    //JoinRoomが失敗したときに呼ばれる
    //失敗するのは人数オーバーとか部屋がないとき
    //カウントして次々検索
    public override void OnJoinRoomFailed(short returnCode,string message)
    {

        Debug.Log(searchRoomName + roomCnt + " is No Exist or Full");

        //検索を進める
        roomCnt++;

        //部屋がある分以上に検索しようとしたら部屋制作に遷移
        if (roomCnt > maxSearchRoomCnt && state == SearchState.JoinRoom)
        {
            state = SearchState.CreateRoom;
        }

        //作るのか検索するのか
        if (state == SearchState.CreateRoom)
        {
            CreateRoom();
        }
        else if (state == SearchState.JoinRoom)
        {
            SearchRoom();
        }
    }
}