using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WordSpawner : MonoBehaviour
{

    public GameObject wordPrefab;

    public Transform wordCanvas;
    public GameObject wordBubblePrefab;

    [SerializeField]
    float _spawnOrigin = -9.0f;

    public List<GameObject> instantiatedGO;

    public WordDisplay SpawnWord(WordManager wordManager)
    {
        Vector3 randomPos = new Vector3(Random.Range(-8f, 8f), -5.5f);

        // Instantiate the wordObj and wordBubbleObj
        GameObject wordObj = Instantiate(wordPrefab, randomPos, Quaternion.identity, wordCanvas);
        GameObject wordBubbleObj = Instantiate(wordBubblePrefab, randomPos, Quaternion.identity, wordObj.transform);

        instantiatedGO.Add(wordObj);


        
        // Set the WordManager reference for the WordDisplay
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
        if (wordDisplay != null)
        {
            wordDisplay.wordManager = wordManager;
        }

        return wordDisplay;
    }

    public void DestroyAllPrefabs()
    {
        if(instantiatedGO.Count > 0)
        {
            for (int i = 0; i < instantiatedGO.Count; i++)
            {
                Destroy(instantiatedGO[i]);
            }
            instantiatedGO.Clear();
        }
    }



    void Update()
    {
        
    }

}
