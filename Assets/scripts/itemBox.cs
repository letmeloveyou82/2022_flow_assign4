using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class itemBox : MonoBehaviour
{
    public PlayerController rudeZbangController;
    float collisionTime;
    float speed;
    int number;
    GameObject item;
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

    }

    void FixedUpdate()
    {
        if (item != null)
        {
            switch (number)
            {
                case 0:
                    StartCoroutine(Boost());
                    break;
                case 1:
                    StartCoroutine(Slow());
                    break;
                case 2:
                    StartCoroutine(Stop());
                    break;
                case 3:
                    StartCoroutine(Change());
                    break;
                case 4:
                    StartCoroutine(Jump());
                    break;


            }
        }
        
    }

    IEnumerator Boost()
    {

        rudeZbangController.speed = speed*2;
        yield return new WaitForSeconds(1f);
        canvas.transform.Find("item0").gameObject.SetActive(false);


        yield return new WaitForSeconds(3f);
        
        rudeZbangController.speed = speed;

        item = null;
        
    }
    IEnumerator Slow()
    {   
        rudeZbangController.speed = speed/2;
        yield return new WaitForSecondsRealtime(1f);
        canvas.transform.Find("item1").gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        rudeZbangController.speed = speed;

        item = null;
    }

    IEnumerator Stop()
    {
        rudeZbangController.speed = 0;
        yield return new WaitForSecondsRealtime(1f);
        canvas.transform.Find("item2").gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        rudeZbangController.speed = speed;
        item = null;
    }

    IEnumerator Change()
    {
        rudeZbangController.left = right;
        rudeZbangController.right = left;
        rudeZbangController.front = back;
        rudeZbangController.back = front;
        yield return new WaitForSecondsRealtime(1f);
        canvas.transform.Find("item2").gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        rudeZbangController.left = left;
        rudeZbangController.right = right;
        rudeZbangController.front = front;
        rudeZbangController.back = back;
        item = null;

    }
    
    IEnumerator Jump()
    {
        yield return new WaitForSecondsRealtime(1f);
        canvas.transform.Find("item2").gameObject.SetActive(false);
        Rigidbody rb = transform.root.GetComponentInChildren<Rigidbody>();
        Debug.Log(rb);
        rb.AddForce(new Vector3(0,100,2000));
        item = null;
    }


        void OnCollisionEnter(Collision collision){
        
        if(collision.gameObject.CompareTag("Item"))
        {

        System.Random rand = new System.Random();
        number = rand.Next(5);

        collisionTime = Time.time;
        item = collision.gameObject;
        item.SetActive(false);
        Debug.Log(number);
        switch (number)
        {
            case 0:
                canvas.transform.Find("item0").gameObject.SetActive(true);
                break;
            case 1:
                canvas.transform.Find("item1").gameObject.SetActive(true);
                break;
            case 2:
                canvas.transform.Find("item2").gameObject.SetActive(true);
                break;
            case 3:
                canvas.transform.Find("item2").gameObject.SetActive(true);
                break;
            case 4:
                canvas.transform.Find("item2").gameObject.SetActive(true);
                break;

        }
    
    }
    }

}
