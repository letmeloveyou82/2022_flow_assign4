using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviourPunCallbacks
{
    public Animator animator;
    public KeyCode left, right, front, back;

    public float speed;
    public float strafeSpeed;
    public float jumpForce;
    public Rigidbody body;
    public bool isGrounded;
    PhotonView PV;
    public Camera cam;
    GameObject finish;
    bool isFinish;
    bool isWinner;
    GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameManager.Instance;
        body = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        cam = transform.root.GetComponentInChildren<Camera>();
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(cam);
            Destroy(body);
        }

        
        //if (scenemanager.getactivescene().name == "endgame")
        //{
        //    if (gamemanager.nickname != "")
        //    {
        //        if (gamemanager.nickname == photonnetwork.nickname)
        //        {
        //            debug.log(photonnetwork.nickname);
        //            body.transform.root.transform.position = new vector3(10, 10, 10);
        //        }
        //        else
        //        {   
        //            body.transform.root.transform.position = new vector3(30, 30, 100);
        //        }
        //    }
        //}


    }


    private void OnTriggerEnter(Collider other)
    {
        
         if(other.gameObject.CompareTag("Finish"))
         {
            finish = other.gameObject;
            Debug.Log(finish);
            Debug.Log("OntriggerEnter");

            if(photonView.IsMine){
                photonView.RPC("setWinner", RpcTarget.All, PhotonNetwork.NickName);

            }
            photonView.RPC("finishGame", RpcTarget.All);
            
         }

    }
    
    [PunRPC]
    private void setWinner(string nickname){
        gameManager.setWinner(nickname);
    }

    [PunRPC]
    private void finishGame() {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(2);


    }


    private void FixedUpdate()
    {
        if (!PV.IsMine)
            return;//내꺼아니면 작동안함

        if (Input.GetKey(front))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);

                body.AddForce(body.transform.forward * speed * 2f);
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);
                body.AddForce(body.transform.forward * speed);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }

        if (Input.GetKey(left))
        {
            animator.SetBool("isSideLeft", true);
            body.AddForce(-body.transform.right * strafeSpeed);
        }
        else
        {
            animator.SetBool("isSideLeft", false);
        }

        if (Input.GetKey(back))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);

                body.AddForce(-body.transform.forward * speed * 2f);
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);

                body.AddForce(-body.transform.forward * speed);
            }
        }
        else if (!Input.GetKey(front))
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }

        if (Input.GetKey(right))
        {
            animator.SetBool("isSideRight", true);
            body.AddForce(body.transform.right * strafeSpeed);
        }
        else if (!Input.GetKey(left))
        {
            animator.SetBool("isSideRight", false);
            animator.SetBool("isSideLeft", false);
        }

        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                body.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
}
