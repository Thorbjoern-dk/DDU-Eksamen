using UnityEngine;

public class SwapScriptControls : MonoBehaviour
{
    public GameObject A1; //Arkæolog
    public GameObject A2; //Ghost
    public GameObject A3; //Box

    private GameObject player1Character;
    private GameObject player2Character;

    void Start()
    {
        // Sæt initiale karakterer til fx A1 og A2
        player1Character = A1;
        player2Character = A2;
    }

    void Update()
    {

        if(player1Character == A1 || player2Character == A1){
            if(player2Character == A2 || player1Character == A2){
                A3.SetActive(false);
            } else{
                A3.SetActive(true);
            }
        }

        // Player 1 input (Venstre Shift)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                TrySwitchCharacter(1, A1);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)){
                TrySwitchCharacter(1, A2);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)){
                TrySwitchCharacter(1, A3);
                A3.SetActive(true);
            }
        }

        // Player 2 input (Højre Shift)
        if (Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                TrySwitchCharacter(2, A1);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)){
                TrySwitchCharacter(2, A2);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)){
                TrySwitchCharacter(2, A3);
                A3.SetActive(true);
            }
        }
    }

    void TrySwitchCharacter(int playerNumber, GameObject targetCharacter)
    {
        GameObject currentCharacter = (playerNumber == 1) ? player1Character : player2Character;
        GameObject otherCharacter = (playerNumber == 1) ? player2Character : player1Character;

        if (targetCharacter == currentCharacter) return; // Allerede denne karakter

        if (targetCharacter == otherCharacter)
        {
            // BYT karakterer
            SwapCharacters(currentCharacter, otherCharacter);

            if (playerNumber == 1)
            {
                player1Character = targetCharacter;
                player2Character = currentCharacter;
            }
            else
            {
                player2Character = targetCharacter;
                player1Character = currentCharacter;
            }
        }
        else
        {
            // SKIFT til inaktiv karakter
            Vector3 tempPos = currentCharacter.transform.position;
            currentCharacter.transform.position = targetCharacter.transform.position;
            targetCharacter.transform.position = tempPos;

            if (playerNumber == 1)
            {
                player1Character = targetCharacter;
            }
            else
            {
                player2Character = targetCharacter;
            }
        }
        InGameOutGameTjek();
    }

    void SwapCharacters(GameObject char1, GameObject char2)
    {
        Vector3 tempPos = char1.transform.position;
        char1.transform.position = char2.transform.position;
        char2.transform.position = tempPos;
    }


    void InGameOutGameTjek(){
        if (player1Character == A1){ //arkæolog
            PlayerMovement isPlayerBool = A1.GetComponent<PlayerMovement>();
            isPlayerBool.IsPlayer1 = true;

            PlayerMovement InGameBool = A1.GetComponent<PlayerMovement>();
            InGameBool.InGame = true;
        } else if (player2Character == A1) {   
            PlayerMovement isPlayerBool = A1.GetComponent<PlayerMovement>();
            isPlayerBool.IsPlayer1 = false;  

            PlayerMovement InGameBool = A1.GetComponent<PlayerMovement>();
            InGameBool.InGame = true;
        } else {
            PlayerMovement InGameBool = A1.GetComponent<PlayerMovement>();
            InGameBool.InGame = false;
        }
        
        
        if (player1Character == A2){ //Ghost
            ChostMovement isPlayerBool = A2.GetComponent<ChostMovement>();
            isPlayerBool.IsPlayer1 = true;

            ChostMovement InGameBool = A2.GetComponent<ChostMovement>();
            InGameBool.InGame = true;
        } else if (player2Character == A2) {   
            ChostMovement isPlayerBool = A2.GetComponent<ChostMovement>();
            isPlayerBool.IsPlayer1 = false;

            ChostMovement InGameBool = A2.GetComponent<ChostMovement>();
            InGameBool.InGame = true;

        } else {
            ChostMovement InGameBool = A2.GetComponent<ChostMovement>();
            InGameBool.InGame = false;
        }
    }
}