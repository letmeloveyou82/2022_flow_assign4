using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{   
    public PlayerController rudeZbangController;
    public GameObject zbang;
    float collisionTime;
    float speed;
    GameObject item;
    
    void Awake() 
    {
        speed = rudeZbangController.speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {        
        if (item != null)
        {
            if(Time.time - collisionTime > 5)
            {
                rudeZbangController.speed = speed;
                item = null;
            } 
        }  


    }

    void OnCollisionEnter(Collision collision){
        
        if(collision.gameObject.CompareTag("Boost"))
        {
        collisionTime = Time.time;
        Debug.Log("collisionTime" + collisionTime);
        item = collision.gameObject;
        item.SetActive(false);

        rudeZbangController.speed = speed*2;
      



        }
    }
}
