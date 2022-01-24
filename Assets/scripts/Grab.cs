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
    public Camera cam;
            Vector3 targetPos;
    // Start is called before the first frame update

    void pickUp()
    {
        if (MyGrabObj!= null)
        {
            if(Input.GetKey(GrabInput))
            {
            if(!IsGrab)
            {  
                Debug.Log("Grabbed");

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

        if (MyGrabObj!= null && IsGrab){
         if(Input.GetMouseButtonUp(0))
         {
             if(MyGrabObj.CompareTag("Item"))
             {

                Vector3 mousePos = Input.mousePosition;
                mousePos.x = mousePos.x-Screen.width/2;
                mousePos.y = mousePos.y - Screen.height/2;
                mousePos.z = 0;
                mousePos.Normalize();
                mousePos.z = 0.5f;
                

                MyGrabObj.GetComponent<Rigidbody>().AddForce(mousePos*50f, ForceMode.Impulse);
                Debug.Log("mousePos"+mousePos);

                IsGrab= false;
                DestroyImmediate(Fj);
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
        MyGrabObj = collision.gameObject;
        Debug.Log(MyGrabObj);
 
        }
        
    }



    // public void OnCollisionExit(Collision other)
    // {
    //     if(other.gameObject.CompareTag("Item"))
    //     {
    //         MyGrabObj = null;
    //     }
    // }
}
