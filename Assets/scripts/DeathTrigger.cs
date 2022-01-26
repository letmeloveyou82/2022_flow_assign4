using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
  public GameObject EndPanel;
  RoomManager rm;
  GameObject zbang;

  // void OnCollisionEnter(Collision collision)
  // {
  //   if (collision.gameObject.CompareTag("Player"))
  //   {
  //     Debug.Log("Dead");
  //     // collision.gameObject.SetActive(false);
  //     // EndPanel.SetActive(true);
      
  //     // StartCoroutine(Move(collision));
  //       // EndPanel.SetActive(true);
  //       float RandomX = UnityEngine.Random.Range(-9, 9);
  //       Debug.Log("before set False");
  //       zbang =  collision.gameObject;
  //       zbang.transform.position = new Vector3(0,0,0);
  //   }
  // }


  public void ExitBtn()
  {
    Debug.Log("ExitBtn");
    SceneManager.LoadScene(0);
  }

  public void StayBtn()
  {
    Debug.Log("StayBtn");
    EndPanel.SetActive(false);
  }
}