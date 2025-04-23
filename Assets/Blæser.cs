using UnityEngine;

public class Blæser : MonoBehaviour
{
    public Vector2 pushDirection = Vector2.right;
    public float pushForce = 10f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player1")||other.CompareTag("Box"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(pushDirection.normalized * pushForce);
            }
        }
        
        if (other.CompareTag("Player2"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(pushDirection.normalized * pushForce * 2);
            }
        }
    }
}
