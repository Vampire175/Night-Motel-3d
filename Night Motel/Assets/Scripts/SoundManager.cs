using UnityEngine;
using System.Collections.Generic;

public enum SoundType
{
    TelephoneRingSound,
    PickupandHangupSound,
    Click,
    JumpScare,
    Walking,
    HorrorBgWhileKilling,
    PaperFloating,
    ScreamingSound,
    ThatSusSound
}

[System.Serializable]
public class SoundClip
{
    public SoundType soundType;
    public AudioClip clip;
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    private AudioSource oneShotAudioSource;
    private AudioSource loopAudioSource;

    [SerializeField] private SoundClip[] soundClips;
    private Dictionary<SoundType, AudioClip> soundDictionary;

    void Awake()
    {
        // Singleton pattern: only one SoundManager should exist
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Optional: persist between scenes

        // Initialize dictionary
        soundDictionary = new Dictionary<SoundType, AudioClip>();
        foreach (var soundClip in soundClips)
        {
            if (!soundDictionary.ContainsKey(soundClip.soundType))
            {
                soundDictionary.Add(soundClip.soundType, soundClip.clip);
            }
            else
            {
                Debug.LogWarning($"SoundManager: Duplicate SoundType {soundClip.soundType} found!");
            }
        }
    }

    private void Start()
    {
        // One AudioSource for PlayOneShot (short sounds)
        oneShotAudioSource = GetComponent<AudioSource>();

        // Separate AudioSource for looping sounds
        loopAudioSource = gameObject.AddComponent<AudioSource>();
        loopAudioSource.loop = true;
    }

    /// <summary>
    /// Play a one-shot sound like click, pickup, jumpscare etc.
    /// </summary>
    public static void PlaySound(SoundType soundType, float volume = 1f)
    {
        if (instance == null)
        {
            Debug.LogWarning("SoundManager: No instance found!");
            return;
        }

        if (instance.soundDictionary.TryGetValue(soundType, out AudioClip clip))
        {
            if (clip != null)
            {
                instance.oneShotAudioSource.PlayOneShot(clip, volume);
            }
            else
            {
                Debug.LogWarning($"SoundManager: Clip for {soundType} is null!");
            }
        }
        else
        {
            Debug.LogWarning($"SoundManager: No clip found for {soundType}!");
        }
    }

    /// <summary>
    /// Play a looping sound (like footsteps) until stopped.
    /// </summary>
    public static void PlayLoopSound(SoundType soundType, float volume = 1f)
    {
        if (instance == null)
        {
            Debug.LogWarning("SoundManager: No instance found!");
            return;
        }

        if (instance.soundDictionary.TryGetValue(soundType, out AudioClip clip))
        {
            if (clip == null)
            {
                Debug.LogWarning($"SoundManager: Clip for {soundType} is null!");
                return;
            }

            if (instance.loopAudioSource.isPlaying && instance.loopAudioSource.clip == clip)
            {
                // Already playing this clip, do nothing
                return;
            }

            instance.loopAudioSource.clip = clip;
            instance.loopAudioSource.volume = volume;
            instance.loopAudioSource.Play();
        }
        else
        {
            Debug.LogWarning($"SoundManager: No clip found for {soundType}!");
        }
    }

    /// <summary>
    /// Stop the current looping sound.
    /// </summary>
    public static void StopLoopSound()
    {
        if (instance == null) return;

        if (instance.loopAudioSource.isPlaying)
        {
            instance.loopAudioSource.Stop();
            instance.loopAudioSource.clip = null;
        }
    }

    /// <summary>
    /// Check if loop sound is playing.
    /// </summary>
    public static bool IsLoopSoundPlaying()
    {
        return instance != null && instance.loopAudioSource.isPlaying;
    }

    /// <summary>
    /// Check if a specific loop sound is playing.
    /// </summary>
    public static bool IsLoopSoundPlaying(SoundType soundType)
    {
        if (instance == null) return false;

        if (instance.soundDictionary.TryGetValue(soundType, out AudioClip clip))
        {
            return instance.loopAudioSource.isPlaying && instance.loopAudioSource.clip == clip;
        }

        return false;
    }

    /// <summary>
    /// Set volume for one-shot sounds.
    /// </summary>
    public static void SetOneShotVolume(float volume)
    {
        if (instance != null)
        {
            instance.oneShotAudioSource.volume = volume;
        }
    }

    /// <summary>
    /// Set volume for looping sounds.
    /// </summary>
    public static void SetLoopVolume(float volume)
    {
        if (instance != null)
        {
            instance.loopAudioSource.volume = volume;
        }
    }

    /// <summary>
    /// Get the current instance (useful for debugging).
    /// </summary>
    public static SoundManager GetInstance()
    {
        return instance;
    }

    private void OnValidate()
    {
        // Check for missing clips in the editor
        if (soundClips != null)
        {
            for (int i = 0; i < soundClips.Length; i++)
            {
                if (soundClips[i].clip == null)
                {
                    Debug.LogWarning($"SoundManager: Missing audio clip for {soundClips[i].soundType}");
                }
            }
        }
    }
}
