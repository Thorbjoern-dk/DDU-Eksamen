using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class ChostMovement : MonoBehaviour
{

    public Animator animator;
    public float MoveSpeed;

    private Rigidbody2D rb;

    PhotonView view;

    public bool IsPlayer1;
    public bool InGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){
        float moveXInput;
        float moveYInput;
        if(IsPlayer1){
            moveXInput = Input.GetAxis("Horizontal")*MoveSpeed*Time.deltaTime;
            moveYInput = Input.GetAxis("Vertical")*MoveSpeed*Time.deltaTime;
            animator.SetBool("IsPlayer1", true);
        } else{
            moveXInput = Input.GetAxis("Horizontal2")*MoveSpeed*Time.deltaTime;
            moveYInput = Input.GetAxis("Vertical2")*MoveSpeed*Time.deltaTime;
            animator.SetBool("IsPlayer1", false);
        }
        if(InGame){
            rb.linearVelocity = new Vector2(moveXInput, moveYInput);
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            SR.enabled = true;
        } else{
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            SR.enabled = true;
        }
        
        if(moveXInput>0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if (moveXInput<0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
