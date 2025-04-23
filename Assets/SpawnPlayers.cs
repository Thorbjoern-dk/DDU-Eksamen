using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject playerPrefab2;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        StartCoroutine(SpawnPlayer());
    }

    IEnumerator SpawnPlayer()
    {
        // Vent på, at netværksobjekterne bliver registreret
        yield return new WaitForSeconds(1.5f);

        if (GameObject.FindWithTag("Player1") != null)
        {
            Debug.Log("Player1 fundet! Spawner PlayerPrefab2.");
            Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(playerPrefab2.name, randomPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("Ingen Player1 fundet. Spawner PlayerPrefab.");
            Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        }
    }
}