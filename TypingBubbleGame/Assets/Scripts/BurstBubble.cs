using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BurstBubble : MonoBehaviour
{
    public GameObject originalBubble;
    public GameObject burstedBubble;

    public bool isInstantiated = false;
    // public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
        originalBubble.SetActive(true);
       
        burstedBubble.SetActive(false);
        

        //anim = gameObject.GetComponent<Animator>();
       
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
        //anim.SetTrigger("Popbubble");
        Debug.Log("Played Animaiton");   
    }
}
