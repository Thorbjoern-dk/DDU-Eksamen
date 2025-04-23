using UnityEngine;

public class StorDørBevægelse : MonoBehaviour
{
    private Vector3 defaultPosition;
    private Vector3 åbenPosition;

    public float åbenY = 5f; // ønsket Y-position, når døren er åben
    public float hastighed = 2f; // hastigheden døren bevæger sig med

    public bool skalÅbnes = false; // kan sættes udefra, f.eks. via knap eller trigger

    void Start()
    {
        defaultPosition = transform.position;
        åbenPosition = new Vector3(defaultPosition.x, åbenY, defaultPosition.z);
    }

    void Update()
    {
        // Midlertidig test: Tryk på E for at toggle døren
        if (Input.GetKeyDown(KeyCode.E))
        {
            skalÅbnes = !skalÅbnes;
        }

        FlytDør();
    }

    void FlytDør()
    {
        Vector3 targetPosition = skalÅbnes ? åbenPosition : defaultPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, hastighed * Time.deltaTime);
    }
}
