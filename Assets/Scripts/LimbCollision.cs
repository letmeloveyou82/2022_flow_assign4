using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController rudeZbangController;
    private void Start()
    {
        rudeZbangController = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        rudeZbangController.isGrounded = true;
        if (collision.gameObject.CompareTag("Trap"))
        {
            Rigidbody rb = GameObject.FindObjectOfType<PlayerController>().transform.root.GetComponentInChildren<Rigidbody>();
            rb.AddForce(new Vector3(0,200,-200), ForceMode.Impulse);
            rudeZbangController.isGrounded = false; 
        }
    }
}