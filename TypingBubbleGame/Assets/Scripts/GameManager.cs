using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WordManager wordManager;
    public WordSpawner wordSpawner;
    public int playerLife = 3;

    public enum GameState {onGame, onPause, gameOver};
    public GameState gameState;

    public enum GameDifficulty {Easy, Medium, Hard};
    public GameDifficulty gameDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLife <= 0)
        {
            gameState = GameState.gameOver;
        }
    }

    public void StartOver()
    {
        playerLife = 3;
        wordManager.words.Clear();
        wordManager.activeWord = null;
        wordManager.hasActiveWord = false;
        gameState = GameState.onGame;
    }
}
