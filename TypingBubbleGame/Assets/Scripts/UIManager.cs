using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public WordSpawner wordSpawner;
    public List<GameObject> healthIcon;
    public GameObject gameOverPanel;
    public GameObject lifePrefab;
    public GameObject settingsButton;
    public GameObject settingsPanel;
    public Transform lifePrefabParent;
    // Update is called once per frame
    void Start()
    {
        while (healthIcon.Count < gameManager.playerLife)
        {
            ShowLifeUI();
        }
    }
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
    public void ShowLifeUI()
    {
        GameObject lifePrefabObj = Instantiate(lifePrefab, lifePrefabParent);
        healthIcon.Add(lifePrefabObj);
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
        wordSpawner.DestroyAllPrefabs();
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        settingsButton.SetActive(false);
    }

    public void RestartGame()
    {
        gameManager.StartOver();
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        settingsButton.SetActive(true);

        while (healthIcon.Count < gameManager.playerLife)
        {
            ShowLifeUI();
        }
    }

    public void OpenSettings()
    {
        gameManager.gameState = GameManager.GameState.onPause;
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
        settingsButton.SetActive(false);
    }
    public void ResumeGame()
    {
        gameManager.gameState = GameManager.GameState.onGame;
        settingsPanel.SetActive(false);
        Debug.Log(settingsPanel.activeInHierarchy);
        settingsButton.SetActive(true);
        Time.timeScale = 1f;

    }
    
}
