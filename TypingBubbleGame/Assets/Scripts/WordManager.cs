using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public bool hasActiveWord;
    public Word activeWord;
    public WordSpawner wordSpawner;
    public WordManager wordManager;
    public int wrongCounter = 0;
    public int outOfBoundsCounter;
    public GameManager gameManager;

    public UIManager uIManager;

    

    void Update()
    {
        // if(wordSpawner.instantiatedGO.Count > 0)
        // {
        //     foreach (var item in wordSpawner.instantiatedGO)
        //     {
        //         if(item != null)
        //         {
        //             item.GetComponentInChildren<BurstBubble>();
        //         }
               
        //     }
        // }
        
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(gameManager.gameDifficulty), wordSpawner.SpawnWord(wordManager));

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
            else
            {
                Damage();
            }
        }
        else
        {
            foreach (var word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        // Check if the active word is out of bounds and remove it
        if (activeWord.wordDisplay.isOutOfBounds)
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            gameManager.playerLife--;
            // Optionally, destroy the game object here if needed
            // Destroy(activeWord.gameObject);
        }


        // Remove the word if it's finished typing the word
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            //StartCoroutine(activeWord.wordDisplay.BurstAndRemoveWord());
            activeWord.wordDisplay.GetComponentInChildren<BurstBubble>().BurstBubbleAnim();
            uIManager.scoreValue ++;
            
        }
    }


    public void ActiveWordDestroyed()
    {
        hasActiveWord = false;
    }

    public void Damage()
    {
        if (gameManager.playerLife > 0)
        {
            gameManager.playerLife--;

        }
        else if (gameManager.playerLife <= 0)
        {
            Debug.Log("GameOver");
            //show game over screen
        }
    }

}
