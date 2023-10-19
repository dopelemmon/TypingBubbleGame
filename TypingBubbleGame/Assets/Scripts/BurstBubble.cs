using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BurstBubble : MonoBehaviour
{
    public GameObject originalBubble;
    public GameObject burstedBubble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y >= 4.5)
        {
            BurstBubbleAnim();
        }
    }

    public void BurstBubbleAnim()
    {
        burstedBubble.SetActive(true);
        originalBubble.SetActive(false);
        Debug.Log("Played Animaiton");
        
    }
}
