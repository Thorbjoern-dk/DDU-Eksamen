using UnityEngine;

public class GhostDoor : MonoBehaviour
{
    
    CapsuleCollider2D bc;
    bool colliderErSlåetFra = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bc = GetComponent<CapsuleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DørTrigger"))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            colliderErSlåetFra = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DørTrigger") && colliderErSlåetFra)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
            colliderErSlåetFra = false;
        }
    }
}
