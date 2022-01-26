using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishController : MonoBehaviour
{   
    GameObject finish;
    GameObject Zbang;
    GameController gameController;
    public TMP_Text timeText;
    public GameObject canvas;
     public void EndGame() 
     {
         Debug.Log("GAME OVER");
     }

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        
    }
     void OnTriggerEnter(Collider other)
     {
            finish = other.gameObject;
            string nickname = other.transform.root.Find("metarig").Find("Hip").GetComponent<PhotonView>().Owner.NickName;
            gameController.setWinner(nickname);
            StartCoroutine(CountDown());


            // rb.transform.root.transform.position = new Vector3 ( 2988, 58,2564);
     }

        // IEnumerator WaitForCountDown()
        // {
        //     yield return StartCoroutine(CountDown());

        // }

        IEnumerator CountDown() 
    {
        canvas.SetActive(true);
        timeText.text = "5";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "4";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "3";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "2";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "1";
        yield return new WaitForSeconds(1.0f);
        timeText.text = "END";
        yield return new WaitForSeconds(1.0f);
        canvas.SetActive(false);
        SceneManager.LoadScene(2);

    }

}
