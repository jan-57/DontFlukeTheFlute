using Unity.VisualScripting;
using UnityEngine;

public class AudioPeriodDetector : MonoBehaviour
{
    [SerializeField] NoteSpawner noteSpawner;
    private AudioSource audioSource;  
    [SerializeField] private float threshold = 0.01f;    // Volume threshold for detection
    [SerializeField] private int sampleSize = 10;          
    [SerializeField] private float minSilenceDuration = 0.01f; // Seconds to confirm end of sound
    [SerializeField] private float minSoundDuration = 0.05f;  // Seconds to confirm start of sound

    [SerializeField] private int noteID;

    private float[] samples;      
    private float volume;         
    private bool isSounding;      // Current state: true if sound period is active //hehe sounding
    private float silenceTimer;   // Timer to debounce silence (sound end)   //just found out about debouncing
    private float soundTimer;     // Timer to debounce sound start

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        samples = new float[sampleSize];
    }

    void FixedUpdate()
    {
        // Check if current frame is above the volume threshold
        bool detected = CheckVolume();

        if (!isSounding)
        {
            // We are not in a sound period yet.
            if (detected)
            {
                soundTimer += Time.deltaTime;
                if (soundTimer >= minSoundDuration)
                {
                    // Confirmed a sound start
                    isSounding = true;
                    soundTimer = 0f;
                    silenceTimer = 0f;
                    OnSoundStart();
                }
            }
            else
            {
                soundTimer = 0f; // Reset if a brief spike doesn't persist
            }
        }
        else
        {
            // We are currently in a sound period.
            if (!detected)
            {
                silenceTimer += Time.deltaTime;
                if (silenceTimer >= minSilenceDuration)
                {
                    // Confirmed the sound has ended
                    isSounding = false;
                    silenceTimer = 0f;
                    soundTimer = 0f;
                    OnSoundEnd();
                }
            }
            else
            {
                silenceTimer = 0f; // Sound continues, reset silence debounce
            }
        }
    }

    // Check the current volume from the audio source
    private bool CheckVolume()
    {
        if (!audioSource.isPlaying) return false;

        audioSource.GetOutputData(samples, 0);

        float sum = 0f;

        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        volume = Mathf.Sqrt(sum / samples.Length); // RMS/ Root Mean Square is the standart for measuring sound amplitude apparently, so its here.

        return volume > threshold;
    }

   
    private void OnSoundStart()
    {
        Debug.Log("soundEnter");
        noteSpawner.SpawnNote(noteID);
    }

    
    private void OnSoundEnd()
    {
        Debug.Log("soundEnter");
    }

    public void ChangeAudioSource(AudioSource newAudioSource)
    {
        audioSource = newAudioSource;
    }
}
