using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {   "apple", "baby", "cake", "duck", "egg",
  "fish", "goat", "hat", "igloo", "jam",
  "kite", "lion", "moon", "nest", "owl",
  "pig", "quack", "rain", "sun", "tree",
  "umbra", "vase", "wig", "xylo", "yarn",
  "zoo", "ant", "bat", "dog", "elf",
  "fox", "gum", "hen", "ink", "jug",
  "key", "lamp", "mop", "nut", "orb",
  "pen", "quill", "rug", "saw", "toy",
  "uke", "vet", "web", "xylo", "yam"};

  private static string[] mediumWordList = {  "guitar", "whisper", "serene", "marvel", "captain",
  "journey", "mystery", "sunset", "butterfly", "laughter",
  "rainbow", "breeze", "fountain", "harmony", "twilight",
  "charming", "wander", "dazzle", "paradise", "whimsical",
  "gratitude", "silence", "tranquil", "adventure", "whispering",
  "radiant", "blossom", "luminous", "elegance", "enchanting",
  "delight", "chocolate", "sparkling", "reflection", "euphoria",
  "scrumptious", "fantastic", "perfection", "gentle", "triumph",
  "passionate", "fantasy", "whispered", "happiness", "magical",
  "mesmerize", "peaceful", "serenity", "mesmerizing", "spellbound"};

  private static string[] hardWordList = {  "Rainy Day", "Bright Moon", "Sweet Honey", "Green Grass", "Blue Sky",
  "Happy Smile", "Cold Water", "Warm Sun", "Open Book", "Quiet Night",
  "Big Heart", "True Love", "Hot Coffee", "New Beginnings", "Cool Breeze",
  "Fresh Air", "Strong Coffee", "Lost Keys", "Golden Sun", "Silver Moon",
  "Sweet Dreams", "Tall Tree", "Soft Pillow", "Red Apple", "Green Tea",
  "White Snow", "Deep Ocean", "Brave Heart", "Sharp Knife", "Big Dog",
  "Little Bird", "Happy Song", "Empty Glass", "Broken Heart", "Wise Owl",
  "Lazy Cat", "Shiny Star", "Dark Night", "Warm Blanket", "Cool Shade",
  "Fast Car", "Slow Motion", "Black Coffee", "Open Door", "Loud Music",
  "Clear Sky", "Sweet Melody", "Lost Time", "Sunny Day", "Peaceful Mind" };

  public GameManager gameManager;
    public static string GetRandomWord(GameManager.GameDifficulty _difficulty)
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord;

        switch (_difficulty)
        {
          case GameManager.GameDifficulty.Easy:
            randomWord = wordList[randomIndex];
            break;
          
          case GameManager.GameDifficulty.Medium:
            randomWord = mediumWordList[randomIndex];
            break;

          case GameManager.GameDifficulty.Hard:
            randomWord = hardWordList[randomIndex];
            break;
          
          default:
            randomWord = wordList[randomIndex];
            break;
        }
        return randomWord;
    }
}
