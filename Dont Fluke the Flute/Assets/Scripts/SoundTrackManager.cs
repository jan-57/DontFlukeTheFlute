using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class SoundTrackManager : MonoBehaviour
{
    [SerializeField] private GameObject[] musicList;
    [SerializeField] private GameObject[] noteList;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private float noteDelay;
    [SerializeField] private GameObject menuSound;
    [SerializeField] private PlayerInput controls;
    [SerializeField] private MenuScript menuScript;
    [SerializeField] private PointSystem pointSystem;
    [SerializeField] private int lastSong;
    private bool wasPlaying = false;

    private void Update()
    {
        if (audioSources[lastSong - 1] == null) return;

        
        if (wasPlaying && !audioSources[lastSong - 1].isPlaying)
        {
            Debug.Log("Audio has stopped!");
            wasPlaying = false;
            OnAudioStopped(); 
        }

        
        wasPlaying = audioSources[lastSong - 1].isPlaying;
    }

    private void OnAudioStopped()
    {
        StopSoundTracks();

        Debug.Log("Perform cleanup or switch tracks.");
    }

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
        Invoke("PlayMusic", noteDelay);
        lastSong = 1;
    }
   

    

    public void StartSoundTrack2()
    {
        noteList[1].SetActive(true);
        Invoke("PlayMusic", noteDelay);
        lastSong = 2;
    }
    
   
    public void StartSoundTrack3()
    {
        noteList[3].SetActive(true);
        Invoke("PlayMusic", noteDelay);
        lastSong = 4;
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

   private void PlayMusic()
    {
        musicList[lastSong - 1].SetActive(true);
    }


}
