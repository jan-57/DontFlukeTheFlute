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

    private Coroutine flashCoroutine;

    void Start()
    {
        IntroSoundSrc.SetActive(true);
        IntroCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

