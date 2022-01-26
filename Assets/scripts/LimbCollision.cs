using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    
    public PlayerController rudeZbangController;
    Rigidbody rb;
    public Rigidbody hip;
    Transform body;
    float speed;
    float strafeSpeed;
    private void Start()
    {
        // rudeZbangController = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        body = rb.transform;
        // hip = GameObject.FindObjectOfType<PlayerController>().transform.root.GetComponentInChildren<Rigidbody>();
        speed = rudeZbangController.speed;
        strafeSpeed = rudeZbangController.strafeSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        rudeZbangController.isGrounded = true;
        if (collision.gameObject.CompareTag("Trap"))
        {
            hip.AddForce(new Vector3(0,10,-300), ForceMode.Impulse);
            rudeZbangController.isGrounded = false; 
        }

        if (collision.gameObject.CompareTag("Climb"))
        {
            rudeZbangController.isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Jump") && (rb.name.Equals("lower_leg.L") || rb.name.Equals("lower_leg.R")))
        {
            rudeZbangController.isGrounded = false;
            hip.AddForce(new Vector3(0,300,0), ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("SlowBox"))
        {
            StartCoroutine(Stop());
        }
    }
        IEnumerator Stop()
    {
        rudeZbangController.speed = 0;
        rudeZbangController.strafeSpeed = 0;
        yield return new WaitForSecondsRealtime(2f);
    
        rudeZbangController.speed = speed;
        rudeZbangController.strafeSpeed = strafeSpeed;
    }
}