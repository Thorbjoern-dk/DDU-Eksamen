using UnityEngine;

public class Blæser : MonoBehaviour
{
    public Vector3 pushDirection = Vector3.right;
    public float pushForce = 10f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player1")) // Sørg for din spiller har tagget "Player1"
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(pushDirection.normalized * pushForce, ForceMode.Force);
            }
        }
    }
}
