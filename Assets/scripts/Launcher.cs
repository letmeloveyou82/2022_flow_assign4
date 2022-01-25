using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher Instance;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject StartGameButton;

    [SerializeField] GameObject SetNickNameButton;
    [SerializeField] TMP_InputField nickNameInputField;
    // Start is called before the first frame update

    void Awake()
    {
        {
            Instance = this;
        }
    }
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings(); //connect master server based on photon server

    }

    public override void OnConnectedToMaster()
    {
        //when connected to master server
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby(); //connect to lobby when we connect to Master server
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnJoinedLobby() // when joined to lobby
    {
        MenuManager.Instance.OpenMenu("start");
        Debug.Log("Joined Lobby");
        //  PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
        // PhotonNetwork.NickName = nickNameInputsField.text;
       
    }

    public void SetNickName()
    {
        PhotonNetwork.NickName = nickNameInputField.text.ToString();
        Debug.Log(PhotonNetwork.NickName);
        Debug.Log(nickNameInputField.text);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);

        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed" + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void StartGame()
    {
        if (string.IsNullOrEmpty(nickNameInputField.text))
        {
            return;
        }
        PhotonNetwork.NickName = nickNameInputField.text;
        
        PhotonNetwork.LoadLevel(1); //build 에서 game scene 번호가 1임
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        {
            PhotonNetwork.JoinRoom(info.Name);
            MenuManager.Instance.OpenMenu("loading");
        }
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
}
