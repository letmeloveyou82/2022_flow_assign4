using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathTrigger : MonoBehaviour
{
  public GameObject EndPanel;

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
    Application.Quit();
    // 대기실 말고 메뉴로 돌아가도록 설정
  }

  public void StayBtn()
  {
    EndPanel.SetActive(false);
    // 카메라 시점을 변경하도록 설정
  }
}