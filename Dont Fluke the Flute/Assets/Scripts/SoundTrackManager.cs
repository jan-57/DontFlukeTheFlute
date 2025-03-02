using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class SoundTrackManager : MonoBehaviour
{
    [SerializeField] private GameObject[] musicList;
    [SerializeField] private GameObject[] noteList;
    [SerializeField] private float noteDelay;
    [SerializeField] private GameObject menuSound;
    [SerializeField] private PlayerInput controls;
    [SerializeField] private MenuScript menuScript;
    [SerializeField] private PointSystem pointSystem;
    private int lastSong;



    public void SwitchToUIControls()
    {
        controls.SwitchCurrentActionMap("Menu");
        menuSound.SetActive(true);
    }

    public void SwitchToGameplayControls()
    {
        controls.SwitchCurrentActionMap("Gameplay");
        menuSound.SetActive(false);
    }

    public void StartSoundTrack1()
    {
        noteList[0].SetActive(true);
        Invoke("music1", noteDelay);
        lastSong = 1;
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
        lastSong = 2;
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
        lastSong = 4;
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
        Invoke("BackToMenu",6);
    }

   private void BackToMenu()
   {
        pointSystem.Reset();
        menuScript.SwitchScreen(lastSong);
        menuScript.SetGaming(false);
   }


}
