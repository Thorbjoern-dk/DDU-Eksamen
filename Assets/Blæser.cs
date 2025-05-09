using UnityEngine;

public class Blæser : MonoBehaviour
{
    public Vector2 pushDirection;
    public float pushForce = 10f;

    public bool flip;

    public float StartRot;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(flip){
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0+StartRot);
        } else{
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180+StartRot);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player1")||other.CompareTag("Box"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if(flip){
                    rb.AddForce(pushDirection.normalized * pushForce * -4);
                } else{
                    rb.AddForce(pushDirection.normalized * pushForce * 4);
                }
            }
        }
        
        if (other.CompareTag("Player2"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if(flip){
                    rb.AddForce(pushDirection.normalized * pushForce * -4);
                } else{
                    rb.AddForce(pushDirection.normalized * pushForce * 4);
                }
            }
        }
    }


}
