using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed; 
    public float strafeSpeed;
    public float jumpForce;
    public KeyCode left, right, front, back;
    
    public Rigidbody body;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        if(Input.GetKey(front))
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

        if(Input.GetKey(left))
        {
            animator.SetBool("isSideLeft", true);
            body.AddForce(-body.transform.right * strafeSpeed);
        }
        else
        {
            animator.SetBool("isSideLeft", false);
        }

        if(Input.GetKey(back))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);

                body.AddForce(-body.transform.forward * speed * 2f);
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);

                body.AddForce(-body.transform.forward * speed);
            }
        }
        else if (!Input.GetKey(front))
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }

        if(Input.GetKey(right))
        {
            animator.SetBool("isSideRight", true);
            body.AddForce(body.transform.right * strafeSpeed);
        }
        else if (!Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isSideRight", false);
            animator.SetBool("isSideLeft", false);
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
