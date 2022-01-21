using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float speed; //forward, back
    public float strafeSpeed; //left and right
    public float jumpForce;

    public Rigidbody hip;
    public bool isGrounded;

    void Start()
    {
        hip = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                hip.AddForce(hip.transform.forward * speed * 1.5f);
            } else 
            {
                hip.AddForce(hip.transform.forward * speed);
            }
        }
    }
}
