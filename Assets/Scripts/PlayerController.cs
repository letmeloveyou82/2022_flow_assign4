using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

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
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);

                body.AddForce(body.transform.forward * speed * 2f);
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);
                body.AddForce(body.transform.forward * speed);
            }
        }
        else 
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }
        if(Input.GetKey(KeyCode.A))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                body.AddForce(-body.transform.right * strafeSpeed * 2f);
            }
            else
            {
                body.AddForce(-body.transform.right * strafeSpeed);
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                body.AddForce(-body.transform.forward * speed * 2f);
            }
            else
            {
                body.AddForce(-body.transform.forward * speed);
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                body.AddForce(body.transform.right * strafeSpeed * 2f);
            }
            else 
            {
                body.AddForce(body.transform.right * strafeSpeed);
            }
        }
        if(Input.GetAxis("Jump") > 0)
        {
            if(isGrounded)
            {
                body.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
}
