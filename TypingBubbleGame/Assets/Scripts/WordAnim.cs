using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WordAnim : MonoBehaviour
{
    float maxWave = 5f;
    float minWave = -5f;
    bool isGoingRight;

    float animSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != maxWave && isGoingRight)
        {
            transform.Translate(1f * animSpeed * Time.deltaTime, 0f, 0f);
        }
        if(transform.position.x == maxWave)
        {
            isGoingRight = false;
        }
        if(transform.position.x != minWave && !isGoingRight)
        {
            transform.Translate(-1f * animSpeed * Time.deltaTime, 0f, 0f);
        }
        if(transform.position.x >= minWave)
        {
            isGoingRight = true;
        }
    }
}
