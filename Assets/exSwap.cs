using UnityEngine;

public class ExSwapScriptControls : MonoBehaviour
{
    public GameObject A1; // Arkæolog
    public GameObject A2; // Ghost
    public GameObject A3; // Box

    public GameObject player1soul;
    public GameObject player2soul;

    private GameObject player1Character;
    private GameObject player2Character;

    public ArdRead ard;

    void Start()
    {
        player1Character = null;
        player2Character = null;

        player1soul.SetActive(false);
        player2soul.SetActive(false);

        UpdateCharacterActiveStates();
        InGameOutGameTjek();
    }

    void Update()
    {
        string slots = ard.GetLatestData();
        // Player 1 input
        if (slots[0] == '1')
        {
            TrySwitchCharacter(1, A1);
        }
        else if (slots[1] == '1')
        {
            TrySwitchCharacter(1, A2);
        }
        else if (slots[2] == '1')
        {
            TrySwitchCharacter(1, A3);
        }
        else
        {
            SpillerSoul(1);
        }

        // Player 2 input

        if (slots[0] == '2')
        {
            TrySwitchCharacter(2, A1);
        }
        else if (slots[1] == '2')
        {
            TrySwitchCharacter(2, A2);
        }
        else if (slots[2] == '2')
        {
            TrySwitchCharacter(2, A3);
        }
        else
        {
            SpillerSoul(2);
        }
    }

    void TrySwitchCharacter(int playerNumber, GameObject targetCharacter)
    {
        GameObject currentCharacter = (playerNumber == 1) ? player1Character : player2Character;
        GameObject otherCharacter = (playerNumber == 1) ? player2Character : player1Character;

        if (targetCharacter == null) return; // stadig en sikring

        if (targetCharacter == currentCharacter) return;

        if (targetCharacter == otherCharacter)
        {
            // BYT karakterer
            if (currentCharacter != null) // kun swap hvis begge eksisterer
            {
                SwapCharacters(currentCharacter, otherCharacter);
            }

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
            Vector3 spawnPos;

            if (currentCharacter != null)
            {
                spawnPos = currentCharacter.transform.position;
            }
            else
            {
                spawnPos = (playerNumber == 1) ? player1soul.transform.position : player2soul.transform.position;
            }

            targetCharacter.transform.position = spawnPos;

            if (playerNumber == 1)
            {
                player1Character = targetCharacter;
                player1soul.SetActive(false);
            }
            else
            {
                player2Character = targetCharacter;
                player2soul.SetActive(false);
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

    void SpillerSoul(int playerNumber)
    {
        if (playerNumber == 1)
        {
            if (player1Character != null)
            {
                player1soul.transform.position = player1Character.transform.position;
                player1Character.SetActive(false);
                player1Character = null;
            }
            player1soul.SetActive(true);
        }
        else
        {
            if (player2Character != null)
            {
                player2soul.transform.position = player2Character.transform.position;
                player2Character.SetActive(false);
                player2Character = null;
            }
            player2soul.SetActive(true);
        }
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
    }
}
