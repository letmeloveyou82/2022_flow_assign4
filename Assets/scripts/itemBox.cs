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
    int number;
    bool haveItem;
    GameObject canvas;
    KeyCode left, right, front, back;
    public AudioSource audioSource;
    public AudioClip boostSound, cannonSound, conversionSound, stopSound, turtleSound;
    void Start()
    {
        canvas = GameObject.Find("items");
        speed = rudeZbangController.speed;
        strafeSpeed = rudeZbangController.strafeSpeed;
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
                        break;
                    case 1:
                        yield return StartCoroutine(Slow());
                        break;
                    case 2:
                        yield return StartCoroutine(Stop());
                        break;
                    case 3:
                        yield return StartCoroutine(Change());
                        break;
                    case 4:
                        yield return StartCoroutine(Jump());
                        break;
                }
            }

        }

    }
    IEnumerator Boost()
    {
        audioSource.PlayOneShot(boostSound);
        rudeZbangController.speed = speed*2;
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
        audioSource.PlayOneShot(turtleSound);
        rudeZbangController.speed = speed/3;
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
        audioSource.PlayOneShot(stopSound);
        rudeZbangController.speed = 0;
        rudeZbangController.strafeSpeed = 0;
        for (int i=5; i>0; i--)
        {
            canvas.transform.Find("StopPanel").Find("time").GetComponent<Text>().text = i + "s";
            yield return new WaitForSecondsRealtime(1f);
        }
        canvas.transform.Find("StopPanel").gameObject.SetActive(false);
    
        rudeZbangController.speed = speed;
        rudeZbangController.strafeSpeed = strafeSpeed;
        haveItem = false;   
    }

    IEnumerator Change()
    {
        audioSource.PlayOneShot(conversionSound);
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
    }

    IEnumerator Jump()
    {
        audioSource.PlayOneShot(cannonSound);
        Rigidbody rb = transform.root.GetComponentInChildren<Rigidbody>();        
        rb.AddForce(new Vector3(0,100,2000));   
        yield return new WaitForSecondsRealtime(3f);
        canvas.transform.Find("JumpPanel").gameObject.SetActive(false);     
        haveItem = false;
    }

    void OnTriggerEnter(Collider collision){
        if (!haveItem)
        {
            if(collision.gameObject.CompareTag("Item"))
            {
                System.Random rand = new System.Random();
                number = rand.Next(5);
                collisionTime = Time.time;
                collision.gameObject.SetActive(false);
                haveItem = true;
                switch (number)
                {
                    case 0:
                        canvas.transform.Find("BoostPanel").gameObject.SetActive(true);
                        break;
                    case 1:
                        canvas.transform.Find("SlowPanel").gameObject.SetActive(true);
                        break;
                    case 2:
                        canvas.transform.Find("StopPanel").gameObject.SetActive(true);
                        break;
                    case 3:
                        canvas.transform.Find("ConversionPanel").gameObject.SetActive(true);
                        break;
                    case 4:
                        canvas.transform.Find("JumpPanel").gameObject.SetActive(true);
                        break;
                }
            }
        }
    }
}