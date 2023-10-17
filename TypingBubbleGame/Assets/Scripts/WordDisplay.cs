using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    public float speed = 1f;

    public void SetWord(string word)
    {
        text.text = word;
    }
    
    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
}
