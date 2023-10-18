using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLife = 3;

    public enum GameState {onGame, onPause, gameOver};
    public GameState gameState;
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
}
