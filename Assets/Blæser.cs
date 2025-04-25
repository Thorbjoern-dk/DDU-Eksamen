using UnityEngine;

public class Blæser : MonoBehaviour
{
    public Vector2 pushDirection;
    public float pushForce = 10f;

    public bool flip;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flip){
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
        } else{
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
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
                    rb.AddForce(pushDirection.normalized * pushForce * -1);
                } else{
                    rb.AddForce(pushDirection.normalized * pushForce);
                }
            }
        }
        
        if (other.CompareTag("Player2"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if(flip){
                    rb.AddForce(pushDirection.normalized * pushForce * -2);
                } else{
                    rb.AddForce(pushDirection.normalized * pushForce);
                }
            }
        }
    }


}
