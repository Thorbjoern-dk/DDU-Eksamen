using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;


    private Rigidbody2D rb;
    private bool isGrounded;

    PhotonView view;

    public bool IsPlayer1;

    public bool InGame;



    void Start(){
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }


    void Update()
    {
        if(view.IsMine){
            Move();
            Jump();
        }
        


    }

    void Move()
    {
        float moveInput;
        if(IsPlayer1){
            moveInput = Input.GetAxis("Horizontal");
        } else{
            moveInput = Input.GetAxis("Horizontal2");
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if(moveInput<0f){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        
        
    }

}
