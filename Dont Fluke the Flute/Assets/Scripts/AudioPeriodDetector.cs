using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
public class AudioPeriodDetector : MonoBehaviour
{
    [SerializeField] NoteSpawner noteSpawner;
    private AudioSource audioSource;
    [SerializeField] private float threshold = 0.1f;         // Increased for WebGL
    [SerializeField] private int sampleSize = 1;             // Maintained at 1
    [SerializeField] private float minSilenceDuration = 0.1f; // Increased for WebGL
    [SerializeField] private float minSoundDuration = 0.1f;   // Increased for WebGL
    [SerializeField] private int noteID;

    private float[] samples;
    private float volume;
    private bool isSounding;
    private float silenceTimer;
    private float soundTimer;
    private bool initialized;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        samples = new float[sampleSize];

#if UNITY_WEBGL
        AudioSettings.outputSampleRate = 48000;
        if (audioSource != null)
        {
           // audioSource.latency = 0.2f;
            audioSource.ignoreListenerPause = true;
            audioSource.ignoreListenerVolume = true;
        }
#endif
    }

    void Start()
    {
        StartCoroutine(WebGLInitialization());
        StartCoroutine(AudioDetectionRoutine());
    }

    IEnumerator WebGLInitialization()
    {
#if UNITY_WEBGL
    // Wait for WebGL audio context to be ready
    yield return new WaitForSeconds(0.5f);
#else
        // Minimal yield for non-WebGL platforms
        yield return null;
#endif

        initialized = true;
        audioSource.Play();
    }

    IEnumerator AudioDetectionRoutine()
    {
        while (true)
        {
            if (initialized)
            {
                bool detected = CheckVolume();
                UpdateSoundState(detected);
            }
            yield return new WaitForSeconds(0.01f); // More precise timing
        }
    }

    void UpdateSoundState(bool detected)
    {
        if (!isSounding)
        {
            if (detected)
            {
                soundTimer += 0.01f;
                if (soundTimer >= minSoundDuration)
                {
                    TriggerSoundStart();
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
                silenceTimer += 0.01f;
                if (silenceTimer >= minSilenceDuration)
                {
                    TriggerSoundEnd();
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

#if UNITY_WEBGL
        // WebGL-compatible volume check
        audioSource.GetOutputData(samples, 0);
        volume = Mathf.Abs(samples[0]);
#else
        // Original desktop check
        audioSource.GetOutputData(samples, 0);
        volume = Mathf.Sqrt(samples[0] * samples[0]);
#endif

        return volume > threshold;
    }

    private void TriggerSoundStart()
    {
        isSounding = true;
        soundTimer = 0f;
        silenceTimer = 0f;
        noteSpawner.SpawnNote(noteID);
    }

    private void TriggerSoundEnd()
    {
        isSounding = false;
        silenceTimer = 0f;
        soundTimer = 0f;
    }

    // Fallback scheduled spawning (use if detection remains unreliable)
    public void ScheduleNotes(List<float> timestamps)
    {
        foreach (var timestamp in timestamps)
        {
            StartCoroutine(SpawnNoteAtTime(timestamp));
        }
    }

    IEnumerator SpawnNoteAtTime(float targetTime)
    {
        while (AudioSettings.dspTime < targetTime)
        {
            yield return null;
        }
        noteSpawner.SpawnNote(noteID);
    }
}