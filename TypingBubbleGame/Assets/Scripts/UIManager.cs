using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public WordSpawner wordSpawner;
    public List<GameObject> healthIcon;
    public GameObject gameOverPanel;
    public TMP_Text congratulationsText;
    public GameObject lifePrefab;
    public GameObject settingsButton;
    public GameObject settingsPanel;
    public GameObject selectDifficultyUI;
    public Transform lifePrefabParent;
    public GameObject scoreInformation;

    public int scoreValue = 0;
    public TMP_Text scoreText;
    bool isSelectingDifficulty = true;
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

        if(isSelectingDifficulty)
        {
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }

        scoreText.text = scoreValue.ToString();
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
        congratulationsText.text = ("Congrats you've completed, " + scoreValue + " words");
    }

    public void RestartGame()
    {
        gameManager.StartOver();
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        settingsButton.SetActive(true);
        //reset the score
        scoreValue = 0;

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

    public void SetDifficultyEasy()
    {
        gameManager.gameDifficulty = GameManager.GameDifficulty.Easy;
        selectDifficultyUI.SetActive(false);
        isSelectingDifficulty = false;
        OnGameUI();

    }

    public void SetDifficultyMedium()
    {
        gameManager.gameDifficulty = GameManager.GameDifficulty.Medium;
        selectDifficultyUI.SetActive(false);
        isSelectingDifficulty = false;
        OnGameUI();
    }
    public void SetDifficultyHard()
    {
        gameManager.gameDifficulty = GameManager.GameDifficulty.Hard;
        isSelectingDifficulty = false;
        selectDifficultyUI.SetActive(false);
        OnGameUI();
    }

    public void OnGameUI()
    {
        scoreInformation.SetActive(true);
        settingsButton.SetActive(true);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    
}
