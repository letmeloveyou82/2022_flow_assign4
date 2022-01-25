using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks
{
    public string nickname = "";

    public static GameManager Instance;

    public void Awake(){
        
        if(Instance){
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void setWinner(string nickname){
        this.nickname = nickname;
    }

    
}
