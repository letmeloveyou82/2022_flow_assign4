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
    float strafeSpeed;
    float jumpForce;
    int number;
    bool haveItem;
    GameObject canvas;
    KeyCode left, right, front, back;
    public AudioSource audioSource;
    public AudioClip boostSound, cannonSound, conversionSound, stopSound, turtleSound, highJumpSound;
    void Start()
    {
        canvas = GameObject.Find("items");
        speed = rudeZbangController.speed;
        strafeSpeed = rudeZbangController.strafeSpeed;
        jumpForce = rudeZbangController.jumpForce;
        left = rudeZbangController.left;
        right = rudeZbangController.right;
        front = rudeZbangController.front;
        back = rudeZbangController.back;
        haveItem = false;
        StartCoroutine(Item());
        audioSource = GetComponent<AudioSource>();
        boostSound = Resources.Load("BackGroundMusic/boostSound") as AudioClip;
        cannonSound = Resources.Load("BackGroundMusic/cannonSound") as AudioClip;
        conversionSound = Resources.Load("BackGroundMusic/conversionSound") as AudioClip;
        stopSound = Resources.Load("BackGroundMusic/stopSound") as AudioClip;
        turtleSound = Resources.Load("BackGroundMusic/turtleSound") as AudioClip;
        highJumpSound = Resources.Load("BackgroundMusic/highJumpSound") as AudioClip;

    }
    void FixedUpdate()
    {
        // if (haveItem)
        // {
        //     switch (number)
        //     {
        //         case 0:
        //             StartCoroutine(Boost());
        //             Debug.Log("finish coroutine : " + haveItem);
        //             break;
        //         case 1:
        //             StartCoroutine(Slow());
        //             Debug.Log("finish coroutine : " + haveItem);
        //             break;
        //         case 2:
        //             StartCoroutine(Stop());
        //             Debug.Log("finish coroutine : " + haveItem);
        //             break;
        //         case 3:
        //             StartCoroutine(Change());
        //             Debug.Log("finish coroutine : " + haveItem);
        //             break;
        //         case 4:
        //             StartCoroutine(Jump());
        //             Debug.Log("finish coroutine : " + haveItem);
        //             break;
        //     }
        // }
    }
    IEnumerator Item()
    {
        while (true)
        {
            yield return null;
            if (haveItem)
            {
                // Debug.Log("haveItem coroutine haveItem : " + number);
                switch (number)
                {
                    case 0:
                        yield return StartCoroutine(Boost());
                        Debug.Log("Finish Boost coroutine");
                        break;
                    case 1:
                        yield return StartCoroutine(Slow());
                        Debug.Log("Finish Slow coroutine");
                        break;
                    case 2:
                        yield return StartCoroutine(Stop());
                        Debug.Log("Finish Stop coroutine");
                        break;
                    case 3:
                        yield return StartCoroutine(Change());
                        Debug.Log("Finish Change coroutine");
                        break;
                    case 4:
                        yield return StartCoroutine(Jump());
                        Debug.Log("Finish Jump coroutine");
                        break;
                    case 5:
                        yield return StartCoroutine(HighJump());
                        break;
                }
            }

        }

    }
    IEnumerator Boost()
    {
        audioSource.PlayOneShot(boostSound);
        Debug.Log("immediately after boost : " + haveItem);
        rudeZbangController.speed = speed*2;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("BoostPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("BoostPanel").gameObject.SetActive(false);
        rudeZbangController.speed = speed;
        haveItem = false;
        Debug.Log("after boost : " + haveItem);
    }

    IEnumerator Slow()
    {
        audioSource.PlayOneShot(turtleSound);
        Debug.Log("immediately after slow : " + haveItem);
        rudeZbangController.speed = speed/3;
        rudeZbangController.strafeSpeed = strafeSpeed/3;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("SlowPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("SlowPanel").gameObject.SetActive(false);

        rudeZbangController.speed = speed;
        rudeZbangController.strafeSpeed = strafeSpeed;
        haveItem = false;
        Debug.Log("after slow : " + haveItem);
    }

    IEnumerator Stop()
    {
        audioSource.PlayOneShot(stopSound);
        Debug.Log("immediately after stop : " + haveItem);
        rudeZbangController.speed = 0;
        rudeZbangController.strafeSpeed = 0;
        rudeZbangController.jumpForce = 0;
        for (int i=3; i>0; i--)
        {
            canvas.transform.Find("StopPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("StopPanel").gameObject.SetActive(false);
    
        rudeZbangController.speed = speed;
        rudeZbangController.strafeSpeed = strafeSpeed;
        rudeZbangController.jumpForce = jumpForce;
        haveItem = false;   
        Debug.Log("after stop : " + haveItem);
    }

    IEnumerator Change()
    {
        audioSource.PlayOneShot(conversionSound);
        Debug.Log("immediately after change : " + haveItem);
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
        rudeZbangController.left = left;
        rudeZbangController.right = right;
        rudeZbangController.front = front;
        rudeZbangController.back = back;
        haveItem = false;
        Debug.Log("after change : " + haveItem);
    }

    IEnumerator Jump()
    {
        audioSource.PlayOneShot(cannonSound);
        Debug.Log("immediately after jump : " + haveItem);
        Rigidbody rb = transform.root.GetComponentInChildren<Rigidbody>();        
        rb.AddForce(new Vector3(0,500,500), ForceMode.Impulse);   
        yield return new WaitForSecondsRealtime(3f);
        canvas.transform.Find("JumpPanel").gameObject.SetActive(false);     
        haveItem = false;
        Debug.Log("after jump : " + haveItem);
    }

    IEnumerator HighJump()
    {
        audioSource.PlayOneShot(highJumpSound);
        rudeZbangController.jumpForce = jumpForce*2;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("HighJumpPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("HighJumpPanel").gameObject.SetActive(false);
        rudeZbangController.jumpForce = jumpForce;
        haveItem = false;

    }

    void OnTriggerEnter(Collider collision){
        Debug.Log("before check haveitem after collision : " + haveItem);
        // Debug.Log("test");
        if (!haveItem)
        {
            // Debug.Log("In if Before check null : " + haveItem);
            if(collision.gameObject.CompareTag("Item"))
            {
                System.Random rand = new System.Random();
                number = rand.Next(6);
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
                    case 5:
                        canvas.transform.Find("HighJumpPanel").gameObject.SetActive(true);
                        Debug.Log("finish collision : " + haveItem);
                        break;
                }
            }
        }
    }
}