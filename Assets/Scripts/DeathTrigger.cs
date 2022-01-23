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
      collision.gameObject.SetActive(false);
      EndPanel.SetActive(true);
    }
  }

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
