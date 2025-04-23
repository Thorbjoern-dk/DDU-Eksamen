using UnityEngine;
using System.Collections.Generic; // Husk at inkludere denne!
public class SwapScript2 : MonoBehaviour
{

    public GameObject Ghost;
    public GameObject Box;
    public GameObject archaeologist;

    public List<string> ActivePlayers = new List<string>();


    string aktivtObjekt1;
    string aktivtObjekt2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ActivePlayers.Add("archaeologist1");// 1 er fordi det er player 1. 
        //ActivePlayers.Add("Ghost2");
        aktivtObjekt1 = "archaeologist1";
        aktivtObjekt2 = "Ghost1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            Debug.Log("Venstre Shift er nede");    

            if (Input.GetKeyDown(KeyCode.Alpha1)){
                SkiftTilObjekt1("archaeologist1");
            } 
            else if (Input.GetKeyDown(KeyCode.Alpha2)){
                SkiftTilObjekt1("Ghost1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)){
                SkiftTilObjekt1("Box1");
            }
        }





        if (Input.GetKey(KeyCode.RightShift)){
            Debug.Log("Højre Shift er nede");
        }



        if(aktivtObjekt1 == "archaeologist1"){
            PlayerMovement isPlayerBool = archaeologist.GetComponent<PlayerMovement>();
            isPlayerBool.IsPlayer1 = true;
        } 

    }
    void SkiftTilObjekt1 (string SkiftTil){
        if(SkiftTil == ("archaeologist1")){
            if(ActivePlayers.Contains("archaeologist1")){
                return;
            } else{
                ActivePlayers.Add("archaeologist1");
                aktivtObjekt1 = "archaeologist1";
            }
        }
    }

}
