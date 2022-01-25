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

    void pickUp()
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
        }

    }

    void Throw()
    {
        if (MyGrabObj!= null){
         if(Input.GetKeyUp(GrabInput))
         {
             if(MyGrabObj.CompareTag("Item"))
             {
                Vector3 speed = new Vector3(0,30,100);
                Debug.Log("UnGrabbed");

                IsGrab= false;
                DestroyImmediate(Fj);
                Debug.Log(Fj);
                
                // Debug.Log(MyGrabObj.transform.root.Find("metarig").Find("Hip").GetComponent<Rigidbody>());
                MyGrabObj.GetComponent<Rigidbody>().AddForce(speed, ForceMode.Impulse);
                // rb.AddForce(speed, ForceMode.Impulse);
                // MyGrabObj.transform.root.Find("metarig").Find("Hip").Translate(speed);
                MyGrabObj = null; 
             }
         }

        }
    }
    void FixedUpdate()
    {
     pickUp();
     Throw();
     }   

    void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.CompareTag("Item"))
        {
            // Debug.Log("collisionEnter");
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
