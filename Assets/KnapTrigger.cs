using UnityEngine;

public class KnapTrigger : MonoBehaviour
{

    public GameObject Dør1;
    public GameObject Dør2;

    public bool RotateBlower;

    public Blæser Blower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Box")){
            if(RotateBlower){
                Blower.flip = true;
            } else{
                StorDørBevægelse Open = Dør1.GetComponent<StorDørBevægelse>();
                Open.skalÅbnes = true;
                StorDørBevægelse Open2 = Dør2.GetComponent<StorDørBevægelse>();
                Open2.skalÅbnes = true;
            }

        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Box")){
            if(RotateBlower){
                Blower.flip = false;
            } else{
                StorDørBevægelse Open = Dør1.GetComponent<StorDørBevægelse>();
                Open.skalÅbnes = false;
                StorDørBevægelse Open2 = Dør2.GetComponent<StorDørBevægelse>();
                Open2.skalÅbnes = false;
            }

        }
    }

}
