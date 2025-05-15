using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreScript : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;

    public float pNumber = 0;

    void Start()
    {
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            pNumber = pNumber +1;
            if(pNumber > 2){
                SceneManager.LoadScene("Game");
            }
        } 

        if(pNumber == 0){
            p1.SetActive(true);
            p2.SetActive(false);
            p3.SetActive(false);
        } else if(pNumber == 1){
            p1.SetActive(false);
            p2.SetActive(true);
            p3.SetActive(false);
        } else if(pNumber == 2){
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(true);
        }

    }
}

