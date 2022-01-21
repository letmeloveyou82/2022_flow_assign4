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
    }
}