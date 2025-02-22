using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOpening : MonoBehaviour
{
    public GameObject IntroSoundSrc;
    public GameObject IntroCanvas;
    public GameObject IntroButton;
    public float flashInterval = 0.5f;
    public GameObject GameCanvas;
    public GameObject Selection1;
    public GameObject Selection2;

    private Coroutine flashCoroutine;

    void Start()
    {
        IntroSoundSrc.SetActive(true);
        IntroCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        Selection1.SetActive(false);
        Selection2.SetActive(false);
        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // CloseOpeningCanvas();
            GameSelection1();
        }
    }

    
    // WHEN YOU PRESS SPACE TO SKIP IT AUTOMATICALLY GOES TO THE 2ND MUSIC CHOICE SO IM TRYING TO FIX THAT RN!! KIND OF TIRED OF UNITY WILL WORK ON THIS LATER - JANEK 

    void GameSelection1()
    {
        
        Selection1.SetActive(true);
        
        StopCoroutine(flashCoroutine);
        IntroButton.SetActive(false);
        IntroCanvas.SetActive(false); 
        IntroSoundSrc.SetActive(false);
        GameCanvas.SetActive(false);
        Selection2.SetActive(false);
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // CloseOpeningCanvas();
            GameSelection2();
        }
    }


    void GameSelection2()
    {
        Selection2.SetActive(true);
        
        StopCoroutine(flashCoroutine);
        IntroButton.SetActive(false);
        IntroCanvas.SetActive(false); 
        IntroSoundSrc.SetActive(false);
        GameCanvas.SetActive(false);
        Selection1.SetActive(false);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // CloseOpeningCanvas();
            CloseOpeningCanvas();
        }
    }
    
    void CloseOpeningCanvas()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            IntroButton.SetActive(false);
            IntroCanvas.SetActive(false); 
            IntroSoundSrc.SetActive(false);
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

