using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Speed for the game is at a playing state
        Time.timeScale = 1;
        //Score in visible
        scoreCanvas.SetActive(true);
        //Game Over UI is invisible
        gameOverCanvas.SetActive(false);
        //The spawner is hown in the game
        spawner.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Game Over Canvas that is used for the game
    [Header("Game Over UI Object for displaying Game Over Screen")]
    public GameObject gameOverCanvas;
    //Score Canvas that is used for the game
    [Header("Score UI Object for displaying score")]
    public GameObject scoreCanvas;
    //Spawner object that is used for the game
    [Header("Spawner Object for spawning objects in game")]
    public GameObject spawner;

    public void GameOver()
    {
        //Game Over UI is visible
        gameOverCanvas.SetActive(true);
        //The spwaner is now invisible in game
        spawner.SetActive(false);
        //The speed for the game is now at a stopping state
        Time.timeScale = 0;
    }
}
