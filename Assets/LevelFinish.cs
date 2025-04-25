using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    bool player1IsFinish;
    bool player2IsFinish;

    public string LevelName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1IsFinish&&player2IsFinish){
            SceneManager.LoadScene(LevelName);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player1")){
            player1IsFinish = true;
        } else if(other.CompareTag("Player2")){
            player2IsFinish = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player1")){
            player1IsFinish = false;
        } else if(other.CompareTag("Player2")){
            player2IsFinish = false;
        }
    }
}
