using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;

    public WordSpawner wordSpawner;
    

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log(word.word);

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if(hasActiveWord)
        {
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (var word in words)
            {
                if(word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        //remove the word if finished typing the word
        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
