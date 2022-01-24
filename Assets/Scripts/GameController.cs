using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public GameObject finish;
    public Rigidbody rb;
     public void EndGame() 
     {
         Debug.Log("GAME OVER");
     }

    void Start()
    {
        rb = transform.root.GetComponentInChildren<Rigidbody>();
        
    }
     private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.CompareTag("Finish"))
         {
             // YouWinPanel.SetActive(true);
             finish = other.gameObject;
             Debug.Log(finish);
             Debug.Log("OntriggerEnter");
             Time.timeScale = 0f;
         }
     }

}
