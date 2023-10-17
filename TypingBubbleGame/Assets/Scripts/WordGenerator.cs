using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {   "apple", "banana", "cat", "dog", "elephant",
  "flower", "guitar", "happiness", "ice cream", "jump",
  "kite", "lemon", "monkey", "nest", "orange",
  "penguin", "queen", "rainbow", "sunshine", "tiger",
  "umbrella", "violin", "watermelon", "xylophone", "yacht",
  "zebra", "balloon", "candle", "dolphin", "eagle",
  "firework", "giraffe", "honey", "island", "jellyfish",
  "kangaroo", "lighthouse", "moon", "ninja", "octopus",
  "puzzle", "quilt", "robot", "star", "train",
  "unicorn", "volcano", "waffle", "x-ray", "yogurt"};
    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}
