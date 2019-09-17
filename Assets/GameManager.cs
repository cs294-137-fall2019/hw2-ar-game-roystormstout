using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool gameStarted = false;
    private static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void startGame()
    {
		Debug.Log("StartGame");
		gameStarted = true;
    }

    public static bool isGameStarted()
    {
        return gameStarted;
    }

    public static void gameEnded()
    {
        gameOver = true;
    }

    public static bool isGameEnded()
    {
        return gameOver;
    }

}
