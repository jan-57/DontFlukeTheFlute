using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class SoundTrackManager : MonoBehaviour
{
    [SerializeField] private GameObject[] musicList;
    [SerializeField] private GameObject[] noteList;
    [SerializeField] private float noteDelay;
    private NokiaControls controls;

    private void Awake()
    {
        controls = new NokiaControls();
    }

    public void SwitchToUIControls()
    {
        
        controls.Gameplay.Disable();
        controls.Menu.Enable();
    }

    public void SwitchToGameplayControls()
    {
        
        controls.Menu.Disable();
        controls.Gameplay.Enable();
    }

    public void StartSoundTrack1()
    {
        noteList[0].SetActive(true);
        Invoke("music1", noteDelay);
    }
    private void music1()
    {
        musicList[0].SetActive(true);
        Invoke("StopSoundTracks", 100);
    }

    public void StartSoundTrack2()
    {
        noteList[1].SetActive(true);
        Invoke("music2", noteDelay);
    }
    private void music2()
    {
        musicList[1].SetActive(true);
        Invoke("StopSoundTracks", 65);
    }
    public void StartSoundTrack3()
    {
        noteList[2].SetActive(true);
        Invoke("music3", noteDelay);
    }
    private void music3()
    {
        musicList[2].SetActive(true);
        Invoke("StopSoundTracks", 32);
    }

    public void StopSoundTracks()
    {
        for (int i = 0; i < musicList.Length; i++)
        {
            musicList[i].SetActive(false);
            noteList[i].SetActive(false);
        }
    }

    public void SwitchActionMap(bool value)
    {
        if (value)
        {
            controls.Gameplay.Enable();
            controls.Menu.Disable();
        }
        else
        {
            controls.Gameplay.Disable();
            controls.Menu.Enable();
        }
    }


}
