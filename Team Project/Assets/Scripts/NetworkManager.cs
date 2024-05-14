using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    private readonly string version = "1.0f";   // 게임 버전 변수
    private string userid = "user";     // 나중에 여기에 저장되 있는 닉네임 불러와서 넣어주면 될듯

    void Awake()
    {
        // 같은 룸의 유저들에게 자동으로 씬을 로딩
        PhotonNetwork.AutomaticallySyncScene = true;
        // 같은 버전의 유저끼리 접속 허용
        PhotonNetwork.GameVersion = version;
        // 유저 아이디 할당
        PhotonNetwork.NickName = userid;
        // 포톤 서버와 통신 횟수 설정 초당 30회
        Debug.Log(PhotonNetwork.SendRate);
        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();

    }

    // 포톤 서버에 접속 후 호출되는 콜백 함수

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby(); // 로비 입장
    }

    // 로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom(); // 랜덤 매치메이킹 기능 제공

    }

    // 랜덤한 룸 입장이 실패했을 경우 호출되는 콜백 함수
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed{returnCode}:{message}");

        // 룸의 속성 정의
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 2;              // 최대 접속자 수
        ro.IsOpen = true;               // 룸의 오픈 여부
        ro.IsVisible = true;            // 로비에서 룸 목록에 노출 시킬지 여부

        PhotonNetwork.CreateRoom("My Room", ro);        // 룸 생성

    }

    // 룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    // 룸이 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        Debug.Log($"Player Conut = {PhotonNetwork.CurrentRoom.PlayerCount}");  // 현재 룸에 접속한 플레이어 수 확인

        // 룸에 접속한 사용자 정보 확인
        foreach(var player in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log($"{player.Value.NickName},{player.Value.ActorNumber}");       // 엑터넘버를 쓰면 고유식별 번호를 알 수 있다.
        }

    }




    void Start()
{

}

// Update is called once per frame
void Update()
{

}
}
