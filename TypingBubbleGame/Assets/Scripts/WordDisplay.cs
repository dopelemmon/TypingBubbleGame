using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    public float speed = 5f;

    [SerializeField]
    float _maxYPosition = 5f;

    public WordManager wordManager;

    public bool isOutOfBounds;

    public BurstBubble burstBubble;

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
        if (wordManager != null)
        {
            wordManager.ActiveWordDestroyed();
        }
        StartCoroutine(BurstAndRemoveWord());
        
        
    }

    void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);

        if(transform.position.y >= 5f)
        {
            isOutOfBounds = true;
            Debug.Log(isOutOfBounds);
            wordManager.Damage();
            Destroy(gameObject);
    
        }
        

    }
     public IEnumerator BurstAndRemoveWord()
    {
         yield return new WaitForSeconds(1.0f); // Adjust the duration as needed (1.0f means 1 second)
         Destroy(gameObject);
     }

}
