using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ButtonGettingFlashed : MonoBehaviour
{
    public float flashInterval = 0.5f;
    public GameObject IntroButton;
    
    
    private Coroutine flashCoroutine;
    void Start()
    {
        flashCoroutine = StartCoroutine(FlashRoutine());
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
