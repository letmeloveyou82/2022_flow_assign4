using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
  public GameObject EndPanel;
  RoomManager rm;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      Debug.Log("Dead");
      // collision.gameObject.SetActive(false);
      // EndPanel.SetActive(true);
      
      // StartCoroutine(Move(collision));
        // EndPanel.SetActive(true);
        float RandomX = UnityEngine.Random.Range(-40, 40);
        collision.gameObject.transform.position = new Vector3(RandomX,25,0);
      // collision.gameObject.transform.Translate(new Vector3(RandomX, 0, 0));
    }
  }

  // IEnumerator Move(Collision collision)
  //   {
  //     Debug.Log("Move() 함수 안");
  //     float RandomX = UnityEngine.Random.Range(-40, 40);
  //     collision.gameObject.transform.position = new Vector3(RandomX,0,0);
  //     yield return new WaitForSecondsRealtime(1.0f);
      
  //   }

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