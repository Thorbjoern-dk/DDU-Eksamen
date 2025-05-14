using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;

    void Start()
    {
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            p1.SetActive(false);
        }

        if (p1.activeInHierarchy == false)
        {
            p2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            p2.SetActive(false);
        }





    }
}
