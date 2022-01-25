using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController rudeZbangController;
    private void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Limb Before change" + rudeZbangController.isGrounded);
        rudeZbangController.isGrounded = true;
        Debug.Log("Limb" + rudeZbangController.isGrounded);
    }
}