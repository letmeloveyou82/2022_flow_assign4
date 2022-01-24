using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countdownTime;
    public GameObject countDown;
    public Text countdownDisplay;
     public PlayerController rudeZbangController;
    private void Start()
    {
        // rudeZbangController = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart() 
    {
        while(countdownTime > 0 )
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        // countdownDisplay.text = "GO!";
        countdownDisplay.gameObject.SetActive(false);
        // rudeZbangController.gameObject.SetActive(true);
    }
}
