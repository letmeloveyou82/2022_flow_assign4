using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{   
    // 따라갈 목표와 위치 오프셋을 public 변수로 선언
    public Transform target; // 카메라가 따라가야할 타겟
    public Vector3 offset; // 오프셋(고정값)
    void Update()
    {
        transform.position = target.position + offset;
    }
    
}
