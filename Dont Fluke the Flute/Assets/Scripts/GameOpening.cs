using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOpening : MonoBehaviour
{
    public GameObject IntroSoundSrc;
    public Canvas IntroCanvas;
    public GameObject IntroButton;
    public float flashInterval = 0.5f;

    private Coroutine flashCoroutine;

    void Start()
    {
        IntroSoundSrc.SetActive(true);
        IntroCanvas.enabled = true;
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
        IntroCanvas.enabled = false;
        IntroSoundSrc.SetActive(false);

        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            IntroButton.SetActive(false);
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

