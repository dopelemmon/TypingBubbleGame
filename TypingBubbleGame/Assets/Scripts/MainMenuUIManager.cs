using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuUIManager : MonoBehaviour
{
    public GameObject howToPlayUI;
    public GameObject[] howToPlayImages;
    public GameObject nextButton;
    public GameObject closeHowToPlayButton;
    public GameObject exitHowToPlayButton;
    public GameObject videoBackground;

    public Animator animator;
    bool isHowToPlayOpen;

    public GameObject introLogo;
    
    public int howToPlayIndex = 0;
    private int showedLogo; // 0 for false, 1 for true

    // Start is called before the first frame update
    void Start()
    {
        showedLogo = PlayerPrefs.GetInt("ShowedLogo", 0); // Load the flag from PlayerPrefs

        if (showedLogo == 0)
        {
            StartCoroutine(IntroLogo());
        }
        else
        {
            introLogo.SetActive(false);
            videoBackground.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(howToPlayUI.activeInHierarchy)
        {
            
            for (int i = 0; i < howToPlayImages.Length; i++)
            {
                if(i == howToPlayIndex)
                {
                    howToPlayImages[i].SetActive(true);
                }

                else
                {
                    howToPlayImages[i].SetActive(false);
                }
            }
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlayButton(bool _HowToPlayBool)
    {
        howToPlayUI.SetActive(_HowToPlayBool);
        howToPlayIndex = 0;
    }

    public void HowToPlayNextButton()
    {
        howToPlayIndex ++;
    }

    public void QuitButton()
    {
        showedLogo = 0;
        PlayerPrefs.SetInt("ShowedLogo", showedLogo);
        PlayerPrefs.Save();
        Application.Quit();
    }

    IEnumerator IntroLogo()
    {   
        animator.Play("FadeInAnimation");
        yield return new WaitForSeconds(5);
        introLogo.SetActive(false);
        videoBackground.SetActive(true);
        showedLogo = 1;
        PlayerPrefs.SetInt("ShowedLogo", showedLogo);
        PlayerPrefs.Save();
    }
}
