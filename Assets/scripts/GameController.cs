using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    GameObject finish;
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
             
            // rb.transform.root.transform.position = new Vector3 ( 2988, 58,2564);
         }
     }

}
