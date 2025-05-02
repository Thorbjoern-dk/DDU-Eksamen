using UnityEngine;

public class SwapScriptControls : MonoBehaviour
{
    public GameObject A1; // Arkæolog
    public GameObject A2; // Ghost
    public GameObject A3; // Box

    private GameObject player1Character;
    private GameObject player2Character;

    void Start()
    {
        // Start med A1 og A2 som aktive spillere
        player1Character = A1;
        player2Character = A2;

        UpdateCharacterActiveStates();
        InGameOutGameTjek();
    }

    void Update()
    {
        // Player 1 input
        if (Input.GetKeyDown(KeyCode.Alpha1)){
                TrySwitchCharacter(1, A1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TrySwitchCharacter(1, A2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                TrySwitchCharacter(1, A3);
        }

        // Player 2 input
        if (Input.GetKeyDown(KeyCode.Comma)){
                TrySwitchCharacter(2, A1);
            }
            else if (Input.GetKeyDown(KeyCode.Period))
            {
                TrySwitchCharacter(2, A2);
            }
            else if (Input.GetKeyDown("-"))
            {
                Debug.Log("fuck dig thorbjørn");
                TrySwitchCharacter(2, A3);
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
            // SKIFT til en inaktiv karakter
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
        UpdateCharacterActiveStates();
    }

    void SwapCharacters(GameObject char1, GameObject char2)
    {
        Vector3 tempPos = char1.transform.position;
        char1.transform.position = char2.transform.position;
        char2.transform.position = tempPos;
    }

    void UpdateCharacterActiveStates()
    {
        A1.SetActive(player1Character == A1 || player2Character == A1);
        A2.SetActive(player1Character == A2 || player2Character == A2);
        A3.SetActive(player1Character == A3 || player2Character == A3);
    }

    void InGameOutGameTjek()
    {
        // A1 - Arkæolog
        PlayerMovement a1Movement = A1.GetComponent<PlayerMovement>();
        if (player1Character == A1)
        {
            a1Movement.IsPlayer1 = true;
            a1Movement.InGame = true;
        }
        else if (player2Character == A1)
        {
            a1Movement.IsPlayer1 = false;
            a1Movement.InGame = true;
        }
        else
        {
            a1Movement.InGame = false;
        }

        // A2 - Ghost
        ChostMovement a2Movement = A2.GetComponent<ChostMovement>();
        if (player1Character == A2)
        {
            a2Movement.IsPlayer1 = true;
            a2Movement.InGame = true;
        }
        else if (player2Character == A2)
        {
            a2Movement.IsPlayer1 = false;
            a2Movement.InGame = true;
        }
        else
        {
            a2Movement.InGame = false;
        }

        // A3 har ingen kontrol-script i denne kode, så vi antager den ikke styres direkte
        // Hvis A3 også skal have `InGame` fx i et "BoxMovement"-script, kan du tilføje det her.
    }
}
