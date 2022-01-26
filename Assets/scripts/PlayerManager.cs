using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;//path사용위해

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;//포톤뷰 선언
    GameObject controller;
    int[] spawnpoint;
    int random;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        spawnpoint = new int[]{-10,-5, 0, 5, 10};
        random = Random.Range(0, 5);
        Debug.Log(random);

    }

    void Start()
    {
        if (PV.IsMine)//내 포톤 네트워크이면
        {
            CreateController();//플레이어 컨트롤러 붙여준다. 
        }
    }
    async void CreateController()//플레이어 컨트롤러 만들기
    {
        Debug.Log("Instantiated Player Controller");
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "rudeZbang"), new Vector3(spawnpoint[random],0,-90), Quaternion.identity, 0, new object[] {PV.ViewID});
        //포톤 프리펩에 있는 플레이어 컨트롤러를 저 위치에 저 각도로 만들어주기
    }
    public void Die()
	{
		PhotonNetwork.Destroy(controller);
		CreateController();
	}
}
