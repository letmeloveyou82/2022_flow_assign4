using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

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
    GameObject canvas;

    public AudioSource audioSource;
    public AudioClip jumpClip;
    GameController gameController;
    PlayerManager playerManager;

    // static AudioSource audioSrc;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        Debug.Log(PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>());
        playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
        Debug.Log(playerManager);


        cam = transform.root.GetComponentInChildren<Camera>();
        canvas = GameObject.Find("EndCanvas"); 
        audioSource = GetComponent<AudioSource>();
        jumpClip = Resources.Load("BackGroundMusic/jumpSound") as AudioClip;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

    }

    void Start()
    {
        
        if (!PV.IsMine)
        {
            Destroy(cam);
            Destroy(body);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("DeathTrigger"))
        {
            playerManager.Die();
        }
    }

    private void FixedUpdate()
    {
        if (!PV.IsMine)
            return;//내꺼아니면 작동안함

        if(Input.GetKey(front))
        {
            if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
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

        if(Input.GetKey(left))
        {
            animator.SetBool("isSideLeft", true);
            body.AddForce(-body.transform.right * strafeSpeed);
        }
        else
        {
            animator.SetBool("isSideLeft", false);
        }

        if(Input.GetKey(back))
        {
            if(Input.GetKey(KeyCode.LeftShift) && isGrounded )
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

        if(Input.GetKey(right))
        {
            animator.SetBool("isSideRight", true);
            body.AddForce(body.transform.right * strafeSpeed);
        }
        else if (!Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isSideRight", false);
            animator.SetBool("isSideLeft", false);
        }

        if(Input.GetAxis("Jump") > 0)
        {
            if(isGrounded)
            {
                body.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
                audioSource.PlayOneShot(jumpClip);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            canvas.transform.Find("EscPanel").gameObject.SetActive(true);
        }
    }
}