using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject[] soundTracks;
    private Nokia controls;

    private void Awake()
    {
        controls = new Nokia();
    }


    public void SwitchToUIControls()
    {
        
        controls.gameplay.Disable();
        controls.menu.Enable();
    }

    public void SwitchToGameplayControls()
    {
        
        controls.menu.Disable();
        controls.gameplay.Enable();
    }

    public void StartSoundTrack1()
    {

    }

    public void StopSoundTracks()
    {
        for (int i = 0; i < soundTracks.Length; i++)
        {
            soundTracks[i].SetActive(false);
        }
    }
}
