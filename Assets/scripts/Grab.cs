using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Rigidbody rb;
    public KeyCode GrabInput;
    public GameObject MyGrabObj;
    FixedJoint Fj;
    public bool IsGrab = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.root.GetComponentInChildren<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
     if (MyGrabObj!= null)
     {
         if(Input.GetKey(GrabInput))
         {
             if(!IsGrab)
             {  
                 Debug.Log("Grabbed");

                // Fj = rb.gameObject.AddComponent<FixedJoint>();
                // Fj.connectedBody = MyGrabObj;
                 Fj = MyGrabObj.AddComponent<FixedJoint>();
                 Fj.connectedBody = rb;
                 Fj.breakForce = 8000;
                 IsGrab= true;
             }
         }
         else if(Input.GetKeyUp(GrabInput))
         {
             if(MyGrabObj.CompareTag("Player"))
             {
                 Debug.Log("UnGrabbed");

                IsGrab= false;
                Destroy(Fj);
                MyGrabObj = null; 
             }
      
         }
     }   
    }
    public void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.CompareTag("Player"))
        {
        Debug.Log("onCollision:Player");
        MyGrabObj = collision.gameObject;
 
        }
        
    }

    // public void OnCollisionExit(Collision other)
    // {
    //     if(other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("ontriggerExit:Player");
    //         MyGrabObj = null;
    //     }
    // }
}
