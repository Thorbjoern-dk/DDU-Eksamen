using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public BoxCollider2D bc;


    private Rigidbody2D rb;
    private bool isGrounded;

    PhotonView view;

    public bool IsPlayer1;

    public bool InGame;



    void Start(){
        rb = GetComponent<Rigidbody2D>();
        //view = GetComponent<PhotonView>();
    }


    void Update()
    {
        Move();
        Jump();



    }

    void Move()
    {
        float moveInput;
        if(IsPlayer1){
            transform.localScale = new Vector3(2, 2, 2);
            moveInput = Input.GetAxis("Horizontal");
            if(InGame){
                animator.SetFloat("Movement", Mathf.Abs(Input.GetAxis("Horizontal")));
                animator.SetBool("IsPlayer1", true);
            }
            bc.size = new Vector2(bc.size.x, 0.87f);
        } else{
            transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            moveInput = Input.GetAxis("Horizontal2");
            if(InGame){
                animator.SetFloat("Movement", Mathf.Abs(Input.GetAxis("Horizontal2")));
                animator.SetBool("IsPlayer1", false);
            }
            bc.size = new Vector2(bc.size.x, 1.1f);
        }
        
        if(InGame){
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            SR.enabled = true;
        } else{
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            SR.enabled = false;
        }
        

        if(moveInput>0f){ //vend den rigtige retning
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if(moveInput<0f){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && IsPlayer1)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && IsPlayer1 == false){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        
        
    }

}
