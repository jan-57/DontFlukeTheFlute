using Unity.VisualScripting;
using UnityEngine;

public class AudioPeriodDetector : MonoBehaviour
{
    [SerializeField] NoteSpawner noteSpawner;
    private AudioSource audioSource;  
    [SerializeField] private float threshold = 0.01f;   
    [SerializeField] private int sampleSize = 10;          
    [SerializeField] private float minSilenceDuration = 0.01f;
    [SerializeField] private float minSoundDuration = 0.05f; 

    [SerializeField] private int noteID;

    private float[] samples;      
    private float volume;         
    private bool isSounding;      
    private float silenceTimer;  
    private float soundTimer;     

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        samples = new float[sampleSize];
    }

    void FixedUpdate()
    {
        
        bool detected = CheckVolume();

        if (!isSounding)
        {
            
            if (detected)
            {
                soundTimer += Time.deltaTime;
                if (soundTimer >= minSoundDuration)
                {
                    
                    isSounding = true;
                    soundTimer = 0f;
                    silenceTimer = 0f;
                    OnSoundStart();
                }
            }
            else
            {
                soundTimer = 0f; 
            }
        }
        else
        {
            
            if (!detected)
            {
                silenceTimer += Time.deltaTime;
                if (silenceTimer >= minSilenceDuration)
                {
                   
                    isSounding = false;
                    silenceTimer = 0f;
                    soundTimer = 0f;
                    OnSoundEnd();
                }
            }
            else
            {
                silenceTimer = 0f; 
            }
        }
    }


    private bool CheckVolume()
    {
        if (!audioSource.isPlaying) return false;

        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i];
        }

        volume = sum / samples.Length;

        return volume > threshold;
    }



    private void OnSoundStart()
    {
        
        noteSpawner.SpawnNote(noteID);
    }

    
    private void OnSoundEnd()
    {
       
    }

    public void ChangeAudioSource(AudioSource newAudioSource)
    {
        audioSource = newAudioSource;
    }
}
