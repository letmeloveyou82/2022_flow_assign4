using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class LoserListItem : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text text;

    public void SetUp(string nickname)
    {
        Debug.Log("setup" + nickname);
        text.text = nickname;
    }

}
