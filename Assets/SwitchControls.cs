using UnityEngine;

public class SwitchControls : MonoBehaviour
{


    public GameObject FysiskKomponentBevægelse;
    public GameObject LokalBevægelse;


    public bool OnOffControlls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnOffControlls = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(OnOffControlls == true){
            LokalBevægelse.SetActive(false);
            FysiskKomponentBevægelse.SetActive(true);
            
        } else{
            LokalBevægelse.SetActive(true);
            FysiskKomponentBevægelse.SetActive(false);
        }


        if(Input.GetKeyDown(KeyCode.Y)){
            Debug.Log("Switch");
            OnOffControlls = !OnOffControlls;
        }
    }
}
