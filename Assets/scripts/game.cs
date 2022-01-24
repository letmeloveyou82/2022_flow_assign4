using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class game : MonoBehaviourPunCallbacks
{
    public string nickname = "";

    public static game Instance;

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
