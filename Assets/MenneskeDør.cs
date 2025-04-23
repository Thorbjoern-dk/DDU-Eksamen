using UnityEngine;

public class MenneskeDør : MonoBehaviour
{

    public BoxCollider2D ColliderRemove;
    bool colliderErSlåetFra = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            ColliderRemove.enabled = false;
            colliderErSlåetFra = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1") && colliderErSlåetFra)
        {
            ColliderRemove.enabled = true;
            colliderErSlåetFra = false;
        }
    }
}
