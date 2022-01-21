using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; 
    public float strafeSpeed;
    public float jumpForce;
    
    public Rigidbody body;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                body.AddForce(body.transform.forward * speed * 1.5f);
            }
            else
            {
                body.AddForce(body.transform.forward * speed);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
                body.AddForce(-body.transform.right * strafeSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
                body.AddForce(-body.transform.forward * speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
                body.AddForce(body.transform.right * strafeSpeed);
        }
    }
}
