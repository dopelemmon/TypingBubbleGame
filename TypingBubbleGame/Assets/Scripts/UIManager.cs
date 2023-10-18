using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> healthIcon;

    public GameObject gameOverPanel;
    // Update is called once per frame
    void Update()
    {
        UpdateHealthUI();
        switch (gameManager.gameState)
        {
            case GameManager.GameState.onGame:
                break;
            case GameManager.GameState.onPause:
                break;
            case GameManager.GameState.gameOver:
                GameOver();
                break;
            
        }
    }

    public void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcon.Count; i++)
        {
            if(i >= gameManager.playerLife)
            {
                
                Destroy(healthIcon[i]);
                healthIcon.Remove(healthIcon[i]);
            }
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

    }
}
