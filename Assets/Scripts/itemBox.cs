using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class itemBox : MonoBehaviour

{
    public PlayerController rudeZbangController;
    float collisionTime;
    float speed;
    int number;
    bool haveItem;
    GameObject canvas;
    KeyCode left, right, front, back;
    void Start()
    {
        canvas = GameObject.Find("items");
        speed = rudeZbangController.speed;
        left = rudeZbangController.left;
        right = rudeZbangController.right;
        front = rudeZbangController.front;
        back = rudeZbangController.back;
        haveItem = false;
        // StartCoroutine(Item());

    }
    void FixedUpdate()
    {
        if (haveItem)
        {
            switch (number)
            {
                case 0:
                    StartCoroutine(Boost());
                    Debug.Log("finish coroutine : " + haveItem);
                    break;
                case 1:
                    StartCoroutine(Slow());
                    Debug.Log("finish coroutine : " + haveItem);
                    break;
                case 2:
                    StartCoroutine(Stop());
                    Debug.Log("finish coroutine : " + haveItem);
                    break;
                case 3:
                    StartCoroutine(Change());
                    Debug.Log("finish coroutine : " + haveItem);
                    break;
                case 4:
                    StartCoroutine(Jump());
                    Debug.Log("finish coroutine : " + haveItem);
                    break;
            }
        }
    }
    // IEnumerator Item()
    // {
    //     while (true)
    //     {
    //         yield return null;
    //         if (haveItem)
    //         {
    //             haveItem = false;
    //             Debug.Log("haveItem coroutine haveItem : " + number);
    //             switch (number)
    //             {
    //                 case 0:
    //                     StartCoroutine(Boost());
    //                     Debug.Log("Finish Boost coroutine");
    //                     break;
    //                 case 1:
    //                     StartCoroutine(Slow());
    //                     Debug.Log("Finish Slow coroutine");
    //                     break;
    //                 case 2:
    //                     StartCoroutine(Stop());
    //                     Debug.Log("Finish Stop coroutine");
    //                     break;
    //                 case 3:
    //                     StartCoroutine(Change());
    //                     Debug.Log("Finish Change coroutine");
    //                     break;
    //                 case 4:
    //                     StartCoroutine(Jump());
    //                     Debug.Log("Finish Jump coroutine");
    //                     break;
    //             }
    //         }

    //     }

    // }
    IEnumerator Boost()
    {
        // Debug.Log("Start Boost");
        rudeZbangController.speed = speed*3;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("BoostPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("BoostPanel").gameObject.SetActive(false);
        rudeZbangController.speed = speed;
        haveItem = false;
    }

    IEnumerator Slow()
    {
        // Debug.Log("Start Slow");
        rudeZbangController.speed = speed/2;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("SlowPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("SlowPanel").gameObject.SetActive(false);

        rudeZbangController.speed = speed;
        haveItem = false;
    }

    IEnumerator Stop()
    {
        // Debug.Log("Start  Stop");
        rudeZbangController.speed = 0;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("StopPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("StopPanel").gameObject.SetActive(false);
    
        rudeZbangController.speed = speed;
        haveItem = false;   
    }

    IEnumerator Change()
    {
        // Debug.Log("Start Change");
        rudeZbangController.left = right;
        rudeZbangController.right = left;
        rudeZbangController.front = back;
        rudeZbangController.back = front;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("ConversionPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("ConversionPanel").gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        rudeZbangController.left = left;
        rudeZbangController.right = right;
        rudeZbangController.front = front;
        rudeZbangController.back = back;
        haveItem = false;
    }

    IEnumerator Jump()
    {
        // Debug.Log("Start Jump");
        yield return new WaitForSecondsRealtime(3f);
        canvas.transform.Find("JumpPanel").gameObject.SetActive(false);
        Rigidbody rb = transform.root.GetComponentInChildren<Rigidbody>();
        // Debug.Log(rb);
        rb.AddForce(new Vector3(0,300,100));        
        haveItem = false;
    }

    void OnTriggerEnter(Collider collision){
        // Debug.Log("Before check null : " + haveItem);
        // Debug.Log("test");
        if (!haveItem)
        {
            // Debug.Log("In if Before check null : " + haveItem);
            if(collision.gameObject.CompareTag("Item"))
            {
                System.Random rand = new System.Random();
                number = rand.Next(5);
                collisionTime = Time.time;
                collision.gameObject.SetActive(false);
                // Debug.Log("collision haveItem 종류 : " + number);
                // Debug.Log("after collision : " + haveItem.ToString());
                haveItem = true;
                switch (number)
                {
                    case 0:
                        canvas.transform.Find("BoostPanel").gameObject.SetActive(true);
                        Debug.Log("finish collision : " + haveItem);
                        break;
                    case 1:
                        canvas.transform.Find("SlowPanel").gameObject.SetActive(true);
                        Debug.Log("finish collision : " + haveItem);
                        break;
                    case 2:
                        canvas.transform.Find("StopPanel").gameObject.SetActive(true);
                        Debug.Log("finish collision : " + haveItem);
                        break;
                    case 3:
                        canvas.transform.Find("ConversionPanel").gameObject.SetActive(true);
                        Debug.Log("finish collision : " + haveItem);
                        break;
                    case 4:
                        canvas.transform.Find("JumpPanel").gameObject.SetActive(true);
                        Debug.Log("finish collision : " + haveItem);
                        break;
                }
            }
        }
    }
}