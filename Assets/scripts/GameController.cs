using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameController : MonoBehaviourPunCallbacks
{
    public static GameController Instance;
    string[] players = new string[PhotonNetwork.PlayerList.Length];
    string winnerPlayer;
    public void Awake(){
        
        if(Instance){
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void setWinner(string winnerNickname){
        Debug.Log("in setWinner");
        this.winnerPlayer = winnerNickname;
        Debug.Log(winnerPlayer);

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++ )
            {
            if (PhotonNetwork.PlayerList[i].NickName != winnerPlayer)
            {
                Debug.Log("Hello!!");
                Debug.Log(PhotonNetwork.PlayerList[i].NickName);

                players[i] = PhotonNetwork.PlayerList[i].NickName;
                Debug.Log(players[i]);

            }
        }
        Debug.Log("winner" + winnerPlayer);
        Debug.Log("players" + players);
    }
    public string getWinner()
    {
        return winnerPlayer;
    }

    public string[] getLosers()
    {
        return players;
    }

    
}
