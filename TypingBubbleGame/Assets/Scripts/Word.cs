using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;

    public WordDisplay wordDisplay;
    public Word(string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        wordDisplay = _display;
        wordDisplay.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        wordDisplay.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if(wordTyped)
        {   
            wordDisplay.RemoveWord();
        }
        return wordTyped;
    }

    
}
