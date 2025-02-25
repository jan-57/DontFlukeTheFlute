using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOpening : MonoBehaviour 
// This as to be one of the worst lines of code i've done i honestly want to shoot myself in the head :p 
// Also going to try to use that shitty thing u told me with the input map or whatever was called 
{
    // public GameObject IntroSoundSrc;
    public GameObject IntroCanvas;
    public GameObject IntroButton;
    public float flashInterval = 0.5f;
    public GameObject GameCanvas;
    public GameObject Selection1;
    public GameObject Selection2;

    
    
    private Coroutine flashCoroutine;

    void Start()
    {
        // IntroSoundSrc.SetActive(true);
        IntroCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        Selection1.SetActive(false);
        Selection2.SetActive(false);
        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { CloseOpeningCanvas();
        
        }
    }

    
    // WHEN YOU PRESS SPACE TO SKIP IT AUTOMATICALLY GOES TO THE 2ND MUSIC CHOICE SO IM TRYING TO FIX THAT RN!! KIND OF TIRED OF UNITY WILL WORK ON THIS LATER - JANEK 
    
    void CloseOpeningCanvas()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            IntroButton.SetActive(false);
            IntroCanvas.SetActive(false); 
         
            GameCanvas.SetActive(true);
        }
    }

    private IEnumerator FlashRoutine()
    {
        while (true)
        {
            IntroButton.SetActive(!IntroButton.activeSelf);
            yield return new WaitForSeconds(flashInterval);
        }
    }
}

