using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Unity의 Inspector 창에서 보고 싶은 것들은 public으로 선언 
    public float speed; 
    // Input Axis 값을 받을 전역변수 선언
    float hAxis;
    float vAxis;
    bool wDown; // walk down
    bool jDown; // jump

    bool isJump; // 지금 점프를 하고 있는지
    bool isDodge; // 지금 회피를 하고 있는지

    // hAxis, vAxis를 합쳐서 만들 moveVec
    Vector3 moveVec;

    Vector3 dodgeVec;

    Rigidbody rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Dodge();
    }

    void GetInput()
    {
        // 키보드 입력, 마우스 입력 모두 Input 클래스에서 관리
        // GetAxisRaw() : Axis값을 정수로 반환하는 함수
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        // Shift 누를 때만 작동되도록 GetButton() 함수 사용
        wDown = Input.GetButton("Walk");
        // space 누르는 즉시 작동
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        // normalized : 방향 값이 1로 보정된 벡터
        // 움직이는 벡터 moveVec
        moveVec = new Vector3(hAxis, 0, vAxis).normalized; //  x축, y축, z축
        dodgeVec = moveVec;
        if(isDodge)
            moveVec = dodgeVec; // 회피 중에는 움직임 벡터 -> 회피방향 벡터로 바뀌도록 구현
        // bool 형태 조건 ? true일 때 값 : false일 때 값(삼항연산자)
        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;
        
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

    }

    void Turn()
    {
        // 3D 회전
        // LookAt() : 지정된 벡터를 향해서 회전시켜주는 함수
        transform.LookAt(transform.position + moveVec);
    }

    void Jump() // 점프
    {
        // moveVec == Vector3.zero 움직이는 함수가 0일 때(움직이지 않을 때)
        if(jDown && moveVec == Vector3.zero && !isJump && !isDodge){
            rigid.AddForce(Vector3.up * 27, ForceMode.Impulse); // 즉각적인 힘 사용 가능
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Dodge() // 회피
    {
        if(jDown && moveVec != Vector3.zero && !isJump && !isDodge){
            dodgeVec = moveVec;
            speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            // 시간차 함수 호출
            Invoke("DodgeOut", 0.5f);
        }
    }

    void DodgeOut() 
    {
        speed *= 0.5f;
        isDodge = false;
    }

    // 이벤트 함수로 착지 구현
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor"){
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }
}
