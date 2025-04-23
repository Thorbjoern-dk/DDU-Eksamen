using UnityEngine;

public class SwapScript : MonoBehaviour
{
    public GameObject Ghost;
    public GameObject Box;
    public GameObject archaeologist;

    private GameObject aktivtObjekt; // Holder styr på det nuværende aktive objekt

    void Start()
    {
        // Du kan evt. sætte en startværdi
        aktivtObjekt = Ghost;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
                Debug.Log("Venstre Shift er nede");
            }

        if (Input.GetKey(KeyCode.RightShift)){
            Debug.Log("Højre Shift er nede");
            }

            
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SkiftTilObjekt(archaeologist);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SkiftTilObjekt(Ghost);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SkiftTilObjekt(Box);
        }
    }

    void SkiftTilObjekt(GameObject nytObjekt)
    {
        if (nytObjekt == aktivtObjekt) return; // Hvis det allerede er aktivt, gør ingenting

        Vector3 tidligerePosition = aktivtObjekt.transform.position;

        // Deaktivér alle objekter
        Ghost.SetActive(false);
        Box.SetActive(false);
        archaeologist.SetActive(false);

        // Flyt og aktivér det nye objekt
        nytObjekt.transform.position = tidligerePosition;
        nytObjekt.SetActive(true);

        // Opdater hvilket objekt der er aktivt
        aktivtObjekt = nytObjekt;
    }
}