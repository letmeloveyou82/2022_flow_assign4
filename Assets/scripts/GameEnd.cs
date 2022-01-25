using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WebSocketSharp;

public class GameEnd : MonoBehaviour
{
    public static GameEnd Instance;

    [SerializeField] TMP_Text winnerNameText;
    [SerializeField] TMP_Text winnerNickNameText;

    [SerializeField] Transform loserListContent;
    [SerializeField] GameObject loserListItemPrefab;
    GameController gameController;
    string winner;
    string[] loser;

    void Awake()
    {
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
            Instance = this;
            winner = gameController.getWinner();
            Debug.Log("gameEnd" + winner);
            loser = gameController.getLosers();
        }
    }

    void Start()
    {
            WinnerUpdate();
            LoserUpdate();
    }

    public void WinnerUpdate()
    {

        //Instantiate(winnerListItemPrefab, winnerContent).text = winner;
        winnerNameText.text = winner;
        winnerNickNameText.text = winner;

    }

    public void LoserUpdate()
    {

        for (int i = 0; i < loser.Length; i++)
        {
            Debug.Log("i: " + i);
            Debug.Log("loser[i]" + loser[i]);
            Instantiate(loserListItemPrefab, loserListContent).GetComponent<LoserListItem>().SetUp(loser[i]);
        }
    }
    //for (int i = 0; i < loser.Length; i++)//{//Instantiate(loserListContent, loserListItemPrefab).text = loser;//}
}
